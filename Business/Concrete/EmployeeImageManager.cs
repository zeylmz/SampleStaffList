using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeImageManager : IEmployeeImageService
    {
        IEmployeeImageDal _employeeImageDal;

        public EmployeeImageManager(IEmployeeImageDal imageDal)
        {
            _employeeImageDal = imageDal;
        }

        public IResult Add(IFormFile file, EmployeeImage employeeImage)
        {
            employeeImage.ImagePath = FileHelper.Add(file);
            employeeImage.Date = DateTime.Now;
            _employeeImageDal.Add(employeeImage);
            return new SuccessResult(Messages.EmployeeImagesSuccessfullyAdded);
        }

        public IResult Delete(EmployeeImage employeeImage)
        {
            FileHelper.Delete(employeeImage.ImagePath);
            _employeeImageDal.Delete(employeeImage);
            return new SuccessResult(Messages.EmployeeImagesSuccessfullyDeleted);
        }

        public IDataResult<List<EmployeeImage>> GetAll()
        {   
            return new SuccessDataResult<List<EmployeeImage>>(_employeeImageDal.GetAll(), Messages.AllEmployeeImageSuccessfullyListed);
        }

        public IDataResult<List<EmployeeImage>> GetByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<EmployeeImage>>(_employeeImageDal.GetAll(e => e.EmployeeId == employeeId), Messages.EmployeeImagesSuccessfullyListed);
        }

        public IDataResult<EmployeeImage> GetById(int id)
        {
            return new SuccessDataResult<EmployeeImage>(_employeeImageDal.Get(e => e.Id == id));
        }

        public IResult Update(IFormFile file, EmployeeImage employeeImage)
        {
            employeeImage.ImagePath = FileHelper.Update(_employeeImageDal.Get(e => e.Id == employeeImage.Id).ImagePath, file);
            employeeImage.Date = DateTime.Now;
            _employeeImageDal.Update(employeeImage);
            return new SuccessResult(Messages.EmployeeImagesSuccessfullyUpdated);
        }
    }
}

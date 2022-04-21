using System;
using System.Collections.Generic;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Business.Constants;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Core.Utilities.Results.Concrete;

namespace TaxiRateApp.Business.Concrete
{
    public class CitiesManager : ICitiesService
    {
        ICitiesDal _citiesDal;

        public CitiesManager(ICitiesDal citiesDal)
        {
            _citiesDal = citiesDal;
        }

        public IResult Add(Cities cities)
        {
            try
            {
                _citiesDal.Add(cities);
                return new SuccessResult(Messages.CityAdded);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Update(Cities cities)
        {
            try
            {
                _citiesDal.Update(cities);
                return new SuccessResult(Messages.CityUpdated);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(Cities cities)
        {
            try
            {
                _citiesDal.Delete(cities);
                return new SuccessResult(Messages.CityDeleted);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<Cities>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Cities>>(_citiesDal.GetAll(x => x.IsActive), Messages.CityGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Cities>>(ex.Message);
            }
        }

        public IDataResult<Cities> GetById(int cityId)
        {
            try
            {
                return new SuccessDataResult<Cities>(_citiesDal.Get(x => x.City_Id == cityId && x.IsActive), Messages.CityGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Cities>(ex.Message);
            }
        }

        public IDataResult<Cities> GetByName(string cityName)
        {
            try
            {
                return new SuccessDataResult<Cities>(_citiesDal.Get(x => x.City_Name.ToLower().Contains(cityName.ToLower()) && x.IsActive), Messages.CityGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Cities>(ex.Message);
            }
        }
    }
}

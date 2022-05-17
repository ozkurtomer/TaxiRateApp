using System;
using System.Threading.Tasks;
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

        public async Task<IResult> Add(Cities cities)
        {
            try
            {
                await _citiesDal.Add(cities);
                return new SuccessResult(Messages.CityAdded);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Update(Cities cities)
        {
            try
            {
                await _citiesDal.Update(cities);
                return new SuccessResult(Messages.CityUpdated);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Delete(Cities cities)
        {
            try
            {
                await _citiesDal.Delete(cities);
                return new SuccessResult(Messages.CityDeleted);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<Cities>>> GetAll()
        {
            try
            {
                var result = await _citiesDal.GetAll(x => x.IsActive);
                return new SuccessDataResult<List<Cities>>(result, Messages.CityGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Cities>>(ex.Message);
            }
        }

        public async Task<IDataResult<Cities>> GetById(int cityId)
        {
            try
            {
                var result = await _citiesDal.Get(x => x.City_Id == cityId && x.IsActive);
                return new SuccessDataResult<Cities>(result, Messages.CityGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Cities>(ex.Message);
            }
        }

        public async Task<IDataResult<Cities>> GetByName(string cityName)
        {
            try
            {
                var result = await _citiesDal.Get(x => x.City_Name.ToLower().Contains(cityName.ToLower()) && x.IsActive);
                return new SuccessDataResult<Cities>(result, Messages.CityGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Cities>(ex.Message);
            }
        }
    }
}

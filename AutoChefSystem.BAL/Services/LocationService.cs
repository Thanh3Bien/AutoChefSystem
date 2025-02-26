using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Location;
using AutoChefSystem.Services.Models.RobotType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageResponse<LocationResponse?>> GetByIdAsync(int id)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id);
            if (location == null)
                return new MessageResponse<LocationResponse?>("Location not found", null);

            return new MessageResponse<LocationResponse?>("Location found", _mapper.Map<LocationResponse>(location));
        }

        public async Task<MessageResponse<PaginatedLocationResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            var locations = await _unitOfWork.Locations.GetAllLocationsAsync(pageNumber, pageSize);

            var mappedList = _mapper.Map<List<LocationResponse>>(locations);

            var result = new PaginatedLocationResponse
            {
                Locations = mappedList,
                Page = pageNumber,
                PageSize = pageSize,
            };

            return new MessageResponse<PaginatedLocationResponse>("Fetched all locations", result);
        }

        public async Task<MessageResponse<LocationResponse>> CreateAsync(CreateLocationRequest request)
        {
            var location = new Location
            {
                LocationName = request.LocationName,
                IsActive = request.IsActive
            };

            await _unitOfWork.Locations.AddLocationAsync(location);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<LocationResponse>("Location created successfully", _mapper.Map<LocationResponse>(location));
        }

        public async Task<MessageResponse<LocationResponse?>> UpdateAsync(int id, UpdateLocationRequest request)
        {
            var existingLocation = await _unitOfWork.Locations.GetByIdAsync(id);
            if (existingLocation == null)
                return new MessageResponse<LocationResponse?>("Location not found", null);

            existingLocation.LocationName = request.LocationName;
            existingLocation.IsActive = request.IsActive;

            await _unitOfWork.Locations.UpdateLocationAsync(existingLocation);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<LocationResponse?>("Location updated successfully", _mapper.Map<LocationResponse>(existingLocation));
        }

        public async Task<MessageResponse<bool>> DeleteAsync(int id)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id);
            if (location == null)
                return new MessageResponse<bool>("Location not found", false);

            await _unitOfWork.Locations.DeleteLocationAsync(id);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<bool>("Location deleted successfully", true);
        }
    }
}

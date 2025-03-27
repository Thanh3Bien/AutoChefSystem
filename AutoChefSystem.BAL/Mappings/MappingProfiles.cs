using AutoChefSystem.Services.Models.Location;
﻿using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Services.Models.Order;
using AutoChefSystem.Services.Models.Recipe;
using AutoChefSystem.Services.Models.RecipeSteps;
using AutoChefSystem.Services.Models.Robots;
using AutoChefSystem.Services.Models.RobotType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Services.Models.RobotOperationLog;
using AutoChefSystem.Services.Services;
using AutoChefSystem.Services.Models.RobotStepTask;

namespace AutoChefSystem.Services.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Recipe
            CreateMap<Recipe, GetAllRecipeResponse>().ReverseMap();
            CreateMap<UpdateRecipeByIdRequest, Recipe>().ReverseMap();
            CreateMap<GetRecipeByIdResponse, Recipe>().ReverseMap();
            CreateMap<CreateRecipeRequest,Recipe>().ReverseMap();
            #endregion

            #region Order
            CreateMap<CreateOrderRequest, Order>().ReverseMap();
            CreateMap<UpdateOrderRequest, Order>().ReverseMap();
            CreateMap<GetOrderByIdResponse, Order>().ReverseMap();
            CreateMap<GetAllOrderResponse, Order>().ReverseMap();
            #endregion

            #region RecipeStep
            CreateMap<RecipeStep, GetByRecipeIdRequest>().ReverseMap();
            CreateMap<CreateRecipeStepRequest, RecipeStep>().ReverseMap();
            CreateMap<UpdateRecipeStepRequest, RecipeStep>().ReverseMap();
            #endregion

            #region Robot
            CreateMap<Robot, RobotResponse>().ReverseMap();
            CreateMap<CreateRobotRequest, Robot>().ReverseMap();
            CreateMap<UpdateRobotRequest, Robot>().ReverseMap();
            #endregion

            #region Robot Type
            CreateMap<RobotType, RobotTypeResponse>().ReverseMap();
            #endregion

            #region Location
            CreateMap<Location, LocationResponse>().ReverseMap();
            #endregion

            #region RobotOperationLog
            CreateMap<RobotOperationLog, RobotOperationLogResponse>().ReverseMap();
            #endregion

            #region RobotStepTask
            CreateMap<RobotStepTask, RobotStepTaskResponse>().ReverseMap();

            CreateMap<UpdateRobotStepTaskRequest, RobotStepTask>()
                .ForMember(dest => dest.EstimatedTime, opt =>
                    opt.MapFrom(src =>string.IsNullOrEmpty(src.EstimatedTime) ? default : TimeOnly.Parse(src.EstimatedTime)));

            #endregion
        }
    }
}

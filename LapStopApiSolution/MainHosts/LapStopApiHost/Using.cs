﻿global using AspNetCoreRateLimit;
global using Common.Models.DynamicObjects;
global using Contracts.DataShaper;
global using Contracts.Hateoas;
global using Contracts.IRepositories;
global using Contracts.IServices;
global using Contracts.Logger;
global using Contracts.Mapping;
global using DTO.Input.FromBody.Creation;
global using DTO.Output.Data;
global using Entities.Context;
global using Entities.InputDtoValidators.Creation;
global using FluentValidation;
global using ImpServices.AutoMapper;
global using ImpServices.AutoMapper.Profiles;
global using ImpServices.DataShaper.UsingExpandoForXmlObject;
global using ImpServices.NLog;
global using LapStopApiHost.Extensions;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using NLog;
global using Repositories;
global using RestfulApiHandler.ActionFilters;
global using RestfulApiHandler.ImpServices.Hateoas;
global using Services;

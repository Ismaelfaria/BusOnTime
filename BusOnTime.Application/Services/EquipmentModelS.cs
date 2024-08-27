﻿using AutoMapper;
using BusOnTime.Application.Interfaces;
using BusOnTime.Application.Mapping.DTOs.InputModel;
using BusOnTime.Application.Mapping.DTOs.ViewModel;
using BusOnTime.Data.Entities;
using BusOnTime.Data.Interfaces.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusOnTime.Application.Services
{
    public class EquipmentModelS : IEquipmentModelS
    {
        private readonly IEquipmentModelR equipmentModelR;
        private readonly IMapper mapper;
        private readonly IValidator<EquipmentModelIM> validator;
        public EquipmentModelS(IEquipmentModelR _equipmentModelR, IMapper _mapper, IValidator<EquipmentModelIM> _validator)
        {
            equipmentModelR = _equipmentModelR;
            mapper = _mapper;
            validator = _validator;
        }
        public async Task<EquipmentModelVM> CreateAsync(EquipmentModelIM entity)
        {
            try
            {
                var validResult = validator.Validate(entity);

                if (!validResult.IsValid)
                {
                    throw new ValidationException("Erro na validação ao criar 'EquipmentModel'");
                }

                var createMapObject = mapper.Map<EquipmentModel>(entity);

                if (createMapObject == null) throw new ArgumentNullException(nameof(createMapObject));

                var view = await equipmentModelR.CreateAsync(createMapObject);

                var viewModel = mapper.Map<EquipmentModelVM>(view);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new Exception("BusOnTime/Application/Services/EquipmentModelS/CreateAsync", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty) throw new ArgumentException("Invalid ID.");

                await equipmentModelR.DeleteAsync(id);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("BusOnTime/Application/Services/EquipmentModelS/DeleteAsync", ex);
            }

        }

        public async Task<IEnumerable<EquipmentModelVM>> FindAllAsync()
        {
            try
            {
                var view = await equipmentModelR.FindAllAsync();

                var viewModel = mapper.Map <IEnumerable<EquipmentModelVM>>(view);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new Exception("BusOnTime/Application/Services/EquipmentModelS/FindAllAsync", ex);
            }
        }

        public async Task<EquipmentModelVM> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty) throw new ArgumentException("Invalid ID.");

                var view = await equipmentModelR.GetByIdAsync(id);

                var viewModel = mapper.Map<EquipmentModelVM>(view);

                return viewModel;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("BusOnTime/Application/Services/EquipmentModelS/FindByIdAsync", ex);
            }
        }

        public async Task UpdateAsync(Guid id, EquipmentModelIM entity)
        {
            try
            {
                var validResult = validator.Validate(entity);

                if (!validResult.IsValid)
                {
                    var errorMessage = string.Join(", ", validResult.Errors.Select(e => e.ErrorMessage));
                    throw new ValidationException($"Validation failed: {errorMessage}");
                }

                var createMapObject = mapper.Map<EquipmentModel>(entity);

                createMapObject.EquipmentId = id;

                if (createMapObject == null) throw new ArgumentNullException(nameof(createMapObject));

                await equipmentModelR.UpdateAsync(createMapObject);
            }
            catch (ArgumentNullException)
            {
                throw;
            }catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("BusOnTime/Application/Services/EquipmentModelS/UpdateAsync", ex);
            }
        }
    }
}

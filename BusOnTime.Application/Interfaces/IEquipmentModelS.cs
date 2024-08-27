﻿using BusOnTime.Application.Interfaces.Generic;
using BusOnTime.Application.Mapping.DTOs.InputModel;
using BusOnTime.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusOnTime.Application.Interfaces
{
    public interface IEquipmentModelS : IServiceBase<EquipmentModel>
    {
        Task<EquipmentModel> CreateAsync(EquipmentModelIM entity);
        Task UpdateAsync(Guid id, EquipmentModelIM entity);
    }
}

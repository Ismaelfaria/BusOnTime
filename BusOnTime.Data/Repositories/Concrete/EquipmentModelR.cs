﻿using BusOnTime.Data.DataContext;
using BusOnTime.Data.Entities;
using BusOnTime.Data.Interfaces.Generic;
using BusOnTime.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusOnTime.Data.Repositories.Concrete
{
    public class EquipmentModelR : RepositoryBase<EquipmentModel>
    {
        public EquipmentModelR(Context context) : base(context)
        {}

        public override async Task<EquipmentModel> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("O ID não pode ser vazio.", nameof(id));
                }

                var entity = await _context.EquipmentModel.SingleOrDefaultAsync(a => a.ModelId == id);

                if (entity == null)
                {
                    throw new KeyNotFoundException("Entidade não encontrada.");
                }

                return entity;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro de argumento: {ex.Message}");
                throw;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Entidade não encontrada: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                throw;
            }
        }
    }
}



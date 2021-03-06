﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoQueryable.Core.Models;
using AutoQueryable.Models;

namespace AutoQueryable.Helpers
{
    public static class OrderByHelper
    {
        public static IEnumerable<Column> GetOrderByColumns(AutoQueryableProfile profile, Clause orderClause, Type entityType)
        {
            if (orderClause == null)
            {
                return null;
            }
            IEnumerable<PropertyInfo> properties = entityType.GetProperties();
            if (profile?.SortableProperties != null)
            {
                properties = properties.Where(c => profile.SortableProperties.Contains(c.Name, StringComparer.OrdinalIgnoreCase));
            }
            if (profile?.UnSortableProperties != null)
            {
                properties = properties.Where(c => !profile.UnSortableProperties.Contains(c.Name, StringComparer.OrdinalIgnoreCase));
            }
            string[] columns = orderClause.Value.Split(',');
            properties = properties.Where(p => columns.Contains(p.Name, StringComparer.OrdinalIgnoreCase));

            return properties.Select(v => new Column
            {
                PropertyName = v.Name
            });
        }
    }
}
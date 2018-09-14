﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using Serilog.Core;
using Serilog.Events;

namespace DestructureCollectionSerilog.Models
{
    public class CollectionDestructuringPolicy<T> : IDestructuringPolicy
    {
        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
            out LogEventPropertyValue result)
        {

            switch (value)
            {
                case City city:
                    result = Destruct(city,propertyValueFactory);
                    return true;
                case ICollection<T> collection:
                    result = Destruct(collection,propertyValueFactory);
                    return true;
            }
            result = null;
            return false;
        }

        private static LogEventPropertyValue Destruct(object collectionItem, ILogEventPropertyValueFactory propertyValueFactory)
        {
            var collectionItemPropertiesNamePerValue = new List<(string propertyName, object propertyValue)>();
            var collectionItemProperties = collectionItem.GetType().GetProperties().ToList();
            collectionItemProperties.ForEach(p => collectionItemPropertiesNamePerValue.Add((propertyName:p.Name, propertyValue:p.GetValue(collectionItem))));
            var properties = new List<LogEventProperty>(collectionItemPropertiesNamePerValue.Count);
            collectionItemPropertiesNamePerValue.ForEach(namePerValue =>
                properties.Add(new LogEventProperty(namePerValue.propertyName,
                    propertyValueFactory.CreatePropertyValue(namePerValue.propertyValue))));
            LogEventPropertyValue result = new StructureValue(properties);
            return result;
        }

        private static LogEventPropertyValue Destruct(IEnumerable<T> collection,
            ILogEventPropertyValueFactory propertyValueFactory)
        {
            var elements = collection.Select(e => propertyValueFactory.CreatePropertyValue(e, true));
            LogEventPropertyValue result = new SequenceValue(elements);
            return result;
        }
    }
}
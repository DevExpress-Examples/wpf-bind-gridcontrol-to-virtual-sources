﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;

namespace ITypedList {
    public class MainViewModel : ViewModelBase {
        public ItemCollection Items { get; }

        static MainViewModel() {
            ItemCollection.CustomFields.Add(new ItemPropertyDescriptor(new CustomField("Name", typeof(string))));
            ItemCollection.CustomFields.Add(
                new ItemPropertyDescriptor(new CustomField("CreatedAt", typeof(DateTime))));
        }

        public MainViewModel() {
            Items = new ItemCollection(Enumerable.Range(0, 10).Select(i => new Item { Id = i }));
            Items.ForEach(x => x["Name"] = $"Item {Items.IndexOf(x)}");
            Items.ForEach(x => x["CreatedAt"] = DateTime.Now.AddDays(Items.IndexOf(x)));

            AddColumnCommand = new DelegateCommand(AddColumn);
        }

        public void AddColumn() {
            var fieldCount = ItemCollection.CustomFields.Count;
            ItemCollection.CustomFields.Add(
                new ItemPropertyDescriptor(new CustomField($"Value {fieldCount}", typeof(int))));
            Items.ForEach(x => x[$"Value {fieldCount}"] = Items.IndexOf(x) * fieldCount);
        }

        public ICommand AddColumnCommand { get; }
    }

    public class Item : BindableBase {
        private readonly Dictionary<string, object> _customFieldValues = new Dictionary<string, object>();

        public int Id { get => GetProperty(() => Id); set => SetProperty(() => Id, value); }

        public object this[string fieldName] {
            get {
                _customFieldValues.TryGetValue(fieldName, out var value);
                return value;
            }

            set {
                _customFieldValues[fieldName] = value;
                RaisePropertyChanged(fieldName);
            }
        }
    }
}
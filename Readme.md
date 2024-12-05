<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/495333708/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1091075)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WPF Data Grid - Bind to Dynamic Data

This example demonstrates various techniques that allow you to bind the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl) to data that changes its structure at runtime.


## The Task

The GridControl is a data-aware control that displays data from a source collection. In most cases, this data is predetermined, and the GridControl uses its property descriptors to obtain data from a data source.

When data source values are calculated at runtime, they are placed in a collection with an arbitrary size. In this collection, the number of rows and columns can change. You cannot use predefined accessors for such values.



## The Standard Technique

To perform this task, you can use the standard WPF data binding. Refer to the following help for information on how to use data bindings in the GridControl: [Binding Columns to Data Source Fields](https://docs.devexpress.com/WPF/120400/controls-and-libraries/data-grid/grid-view-data-layout/columns-and-card-fields/binding-columns-to-data-source-fields).

In certain cases and with a large amount of data, bindings may cause performance issues. We recommend that you use bindings for columns only when it is necessary. For example, to display unsupported data formats with custom cell templates or to make the GridControl work with the interface inheritance.


## The DevExpress Technique

* The GridControl can contain [Unbound Columns](https://docs.devexpress.com/WPF/6124/controls-and-libraries/data-grid/grid-view-data-layout/columns-and-card-fields/unbound-columns). These columns can display any values and are suitable for dynamic data. Handle the [CustomUnboundColumnData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomUnboundColumnData) event to manually fetch and save edited data.
* You can also use our [Virtual Data Sources](https://docs.devexpress.com/WPF/10803/controls-and-libraries/data-grid/bind-to-data/bind-to-any-data-source-with-virtual-sources) for this task. Such sources support [Custom Properties](https://docs.devexpress.com/WPF/DevExpress.Xpf.Data.VirtualSourceBase.CustomProperties) that allow you to define custom property descriptors.


## Considerations

* Use the [ExpandoObject](https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject) technique if you need to add fields to your data source at runtime.
* The [ICustomTypeDescriptor](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.icustomtypedescriptor) and [ITypedList](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedlist) interfaces allow you to use custom property descriptors so you can change the way data is fetched from your data source.
* Use the [DataTable](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable) technique if you need to programmatically control rows and columns.


## Comparison

| Technique |Complexity\*|Overall Performance (1M rows)\*\*|Sorting|Filtering (even records)|Scrolling|
|--|--|--|--|--|--|
|[Unbound Columns](/CS/Unbound_Columns) ([VB](/VB/Unbound_Columns))|Simple|Average|1.5x|1.5x|0.4x|
|[Virtual Data Source](/CS/VirtualSources.InfiniteAsyncSource) ([VB](/VB/VirtualSources.InfiniteAsyncSource))\*\*\*|Average|Good|-|-|-|
|[ExpandoObject](/CS/ExpandoObject) ([VB](/VB/ExpandoObject))|Average|Good|0.5x|1.4x|0.5x|
|[ICustomTypeDescriptor](/CS/ICustomTypeDescriptor) ([VB](/VB/ICustomTypeDescriptor))|Difficult|Average|2x|1.5x|0.3x|
|[ITypedList](/CS/ITypedList) ([VB](/VB/ITypedList))|Difficult|Average|1.5x|1.6x|0.4x|
|[DataTable](/CS/DataTable) ([VB](/VB/DataTable))|Simple|Reduced|0.5x|3.8x|0.6x|

\* The complexity is mostly measured by our subjective opinion and the aggregate necessity to create custom classes, implement interfaces, or handle events.

\*\* The exact time may differ based on the project implementation or machine specifications. This table shows relative values measured in multiple attempts on the same machine.

\*\*\* When you add new columns to a virtual data source at runtime, you should reset the source and fetch all rows. The performance of common data shaping operations depends on custom logic that implements such operations in the source.



## Documentation

* [WPF Data Grid: Bind to Data](https://docs.devexpress.com/WPF/7352/controls-and-libraries/data-grid/bind-to-data)
* [Bind the WPF Data Grid to any Data Source with Virtual Sources](https://docs.devexpress.com/WPF/10803/controls-and-libraries/data-grid/bind-to-data/bind-to-any-data-source-with-virtual-sources)
* [Unbound Columns](https://docs.devexpress.com/WPF/6124/controls-and-libraries/data-grid/grid-view-data-layout/columns-and-card-fields/unbound-columns)


## More Examples

* [Bind the WPF Data Grid to Data](https://github.com/DevExpress-Examples/how-to-bind-wpf-grid-to-data)
* [Implement CRUD Operations in the WPF Data Grid](https://github.com/DevExpress-Examples/how-to-implement-crud-operations#implement-crud-operations-in-the-wpf-data-grid)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-bind-gridcontrol-to-dynamic-data&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-bind-gridcontrol-to-dynamic-data&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

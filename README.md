# RazorAlerts
Super simple RazorClassLibrary to show bootstrap (or other html alerts)

## Installation

Install the NugetPackage Sustainable.Web.RazorAlerts

## Usage

### In the views

In the _Layout.cshtml add the line 
```cshtml
<partial name="_Alerts" />
```
Where you want to display the alerts.

In ajax provided partial views place the following line in the bottom of the view:
```cshtml
<partial name="_PushAlerts" />
```

### In the controllers

Make sure to include the following using line to load the extension methods
```csharp
using RazorAlerts;
```

In order to add an alert to a response simply type the following line

```csharp
this.AddWarning("Warning", "Not really just a test");
```

## Overwrite Alert HTML 

Create a file in `Views/Shared` named `_Alert.cshtml` makes sure is uses the model `RazorAlerts.Alert` and fill it with your display code for the Alert:

```cshtml
@model RazorAlerts.Alert
<div class="alert alert-@Model.Type.ToString().ToLowerInvariant() alert-dismissible" role="alert">
    @if (Model.Dismissable)
    {
        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
    }
    <strong>@Model.Title!!!!</strong> @Model.Body
</div>
```

## Unit testing

All alerts are added to the TempData variable, this variable can be enumerated and checked for the correct Alerts.

The default key for the TempData entry is `Alerts`, this can be overwritten by setting the static variable `RazorAlerts.AlertExtensions.AlertKey` with a custom string 
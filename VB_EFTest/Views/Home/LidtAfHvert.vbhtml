@ModelType VB_EFTest.LaHv
@Code
    ViewData("Title") = "LidtAfHvert"
    Dim MyList = New List(Of SelectListItem)()

    MyList.Add(New SelectListItem() With {.Value = "1", .Text = Model.ListBoxItems.Color1})
    MyList.Add(New SelectListItem() With {.Value = "2", .Text = Model.ListBoxItems.Color2})
    MyList.Add(New SelectListItem() With {.Value = "3", .Text = Model.ListBoxItems.Color3})
    MyList.Add(New SelectListItem() With {.Value = "4", .Text = Model.ListBoxItems.Color4})
    MyList.Add(New SelectListItem() With {.Value = "5", .Text = Model.ListBoxItems.Color5})
    MyList.Add(New SelectListItem() With {.Value = "6", .Text = Model.ListBoxItems.Color6})

   
End Code

<h2>LidtAfHvert</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div >
        <h4>LaHv</h4>
        <hr />
       <p style="color:purple">@ViewBag.Result</p>
        <div  class="form-group" >
             @Html.LabelFor(Function(Model) Model.Name)
             <div>
                @Html.TextBoxFor(Function(Model) Model.Name, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group" >
            @Html.LabelFor(Function(Model) Model.Occupied)
            <div>
                @Html.CheckBoxFor(Function(Model) Model.Occupied, New With {.class = "b-form-checkbox"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.ListBoxItems)
            <div>
                @Html.ListBoxFor(Function(Model) Model.ListBoxItems, MyList, New With { .class = "form-control", .size = "4"})
            </div>
        </div>
    <br/>
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @*@Html.ActionLink("Back to List", "Index")*@
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
    <script>
        
        $(function () {
            $("#ListBoxItems").removeAttr("multiple");
            setTimeout("$('p').text('')", 3000);
            //$("p").text("");
        });
    </script>

End Section

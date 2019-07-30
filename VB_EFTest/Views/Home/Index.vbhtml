@Code
    ViewData("Title") = "Home Page"

    Dim x As SelectList = ViewBag.Deps
    
   

End Code



<div class="row">
  <p class="header">Here we are,xxx my friend....</p>

  <div>
      @Html.DropDownList("Departments", x, New With {.class = "form-control"})

      <table class="table" id="tblEmps">
          <thead>
              <tr>
                  <th>
                      Alias
                  </th>
                  <th>
                      Name
                  </th>
                  <th>
                      E-mail
                  </th>
                  <th>
                      Remarks
                  </th>
                  <th>
                      Mobile
                  </th>
              </tr>
          </thead>
          <tbody></tbody>
      </table>
  </div>
</div>  

<script src="~/Scripts/jquery-3.3.1.min.js"></script>
<script>
    $(function () {

              DepChange = function () {
                   $("#tblEmps tbody tr").remove();
                $.ajax({
                    type: 'POST',
                    url: '@Url.Action("GetEmployees")',
                    dataType: 'json',
                    data: { id: $("#Departments").val() },
                    success: function (data) {
                        var items = '';
                        $.each(data, function (i, emp) {

                            var rows = "<tr>"
                               // + "<td empid=\"" + emp.ID + "\" ><a href=\"" + "/Employees/Edit/" + emp.ID + "\">" + emp.Alias + "</td>"
                            + "<td>" + emp.Alias + "</td>"
                            + "<td >" + emp.Name + "</td>"
                            + "<td >" + emp.HomeEmail + "</td>"
                            + "<td >" + emp.Remarks + "</td>"
                            + "<td >" + emp.Mobile + "</td>"
                            + "</tr>";
                            $('#tblEmps tbody').append(rows);
                        });

                    },
                    error: function (xhr,status,error) {
                        var a, b, c;
                        a = xhr;
                        b = status;
                        c = error;
                    }
                }); 
                return false;
        }


                $("#Departments").change(function () {
                    $(".header").text("Changed..... " + $("#Departments option:selected").text());
                    DepChange();
                });

        DepChange();
});
</script>

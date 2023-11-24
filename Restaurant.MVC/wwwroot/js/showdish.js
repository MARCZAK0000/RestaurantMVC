const currentScriptGetDish = document.currentScript;
$(document).ready(function () {
    let TotalPage = 0;
    let PageSize = 5;
    let PageNumber = 1;
    const RenderCarWorkshopServices = (data) => {
        if (data.items.length > 0) {
            $("#dish-services-container").html(
                `
                    <table class="table">
                        <thead>
                            <tr>
                                <th class="col">Name</th>
                                <th class="col">Description</th>
                                <th class="col">Price w PLN mordeczko :D )</th>
                                <th class="col">Details</th>
                                <th class="col">Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                            
                        </tbody>
                    </table>
                `
            )
            for (var i = 0; i < data.items.length; i++) {
                console.log(data.items[i]);
                $("#dish-services-container table tbody").append(
                    `       
                            <tr>
                                <td>${data.items[i].name}</td>
                                <td>${data.items[i].describition}</td>
                                <td>${data.items[i].price}</td>
                                <td>
                                    <a data-encodedName=${data.items[i].encodedName} class = "dish-edit-service btn btn-info">Details</a>
                                </td>
                                <td>
                                    <a data-encodedName=${data.items[i].encodedName} class = "dish-delete-button btn btn-danger">Delete</a> 
                            </tr>
                        `
                )
            }

            return
        }
        $("#dish-services-container").html(
            "<p class = 'display-6'>No dishes</p>"
        )       
    }
    const LoadDishService = (pageNumber, pageSize) => {
        const encodeName = currentScriptGetDish.getAttribute('data-encodedName');
        const url = `https://localhost:7152/Restaurant/${encodeName}/Dish?pageNumber=${pageNumber}&pageSize=${pageSize}`;
        $.ajax({
            url: url,
            type: 'get',
            success: function (data) {
                TotalPage = Math.ceil(data.totalItems / PageSize);
                RenderCarWorkshopServices(data)
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
        
        
    }
    LoadDishService(PageNumber, PageSize);
    $("#dish-page-up").click(function () {
        if (PageNumber < TotalPage) {
            PageNumber = PageNumber + 1;
        }
        
        LoadDishService(PageNumber, PageSize)
    });
    $("#dish-page-down").click(function () {
        if (PageNumber === 1) {
            PageNumber = 1
        }
        else {
            PageNumber = PageNumber - 1;
        }
        LoadDishService(PageNumber, PageSize)
    });
    $("#dish-page-size").on("change", function () {
        PageSize = this.value
        LoadDishService(1, PageSize);
    });
    $("#dish-page-refresh").click(function () {
        LoadDishService(1, PageSize);
    })

    $(document).on("click", ".dish-delete-button", function ()
    {   
        const restaurantEncodedName = currentScriptGetDish.getAttribute('data-encodedName')
        const dishEncodedName = $(this).attr("data-encodedName")
        const url = `https://localhost:7152/Restaurant/${restaurantEncodedName}/Dish/${dishEncodedName}`;
        $.ajax(
            {
                type: "DELETE",
                url: url,
                success: function (data) {
                    toastr["success"]("Congratulations")
                    LoadDishService(1, PageSize)
                },
                error: function (data) {
                    toastr["error"]("Something went wrong")
                }
            }
        )
    })
});

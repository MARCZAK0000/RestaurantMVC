const currentScriptGetDish = document.currentScript;


$(document).ready(function () {
    let TotalPage = 0;
    const PageSize = 3;
    let PageNumber = 1;
    const RenderCarWorkshopServices = (data) => {
        const TotalItems = data.Length;
        TotalPage = data.totalItems % PageSize == 0 ? Math.ceil(data.totalItems / PageSize) : Math.ceil((data.totalItems /PageSize)+1)
        const ItemsFrom = PageSize * (PageNumber - 1) + 1;
        const ItemsTo = (PageSize * (PageNumber - 1) + 1) + PageSize - 1;
        console.log(data);
        console.log(TotalPage);
        console.log(data.items.length)

        if (data.items.length > 0) {
            $("#dish-services-container").html(
                `
                    <table class="table">
                        <thead>
                            <tr>
                                <th class="col">Name</th>
                                <th class="col">Description</th>
                                <th class="col">Price w PLN mordeczko :D )</th>
                            </tr>
                        </thead>
                        <tbody>
                            
                        </tbody>
                    </table>
                `
            )
            console.log('hello')
            for (var i = 0; i < data.items.length; i++) {
                console.log(data.items[i].name)
                $("#dish-services-container table tbody").append(
                    `       
                            <tr>
                                <td>${data.items[i].name}</td>
                                <td>${data.items[i].describition}</td>
                                <td>${data.items[i].price}</td>
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



    const LoadDishService = (pageNumber) => {
        const encodeName = currentScriptGetDish.getAttribute('data-encodedName');
        const url = `https://localhost:7152/Restaurant/${encodeName}/Dish?pageNumber=${pageNumber}`;
        console.log(url);

        $.ajax({
            url: url,
            type: 'get',
            success: function (data) {
                RenderCarWorkshopServices(data)
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
        
        
    }



    LoadDishService(PageNumber);



    $("#dish-page-up").click(function () {
        if (PageNumber < TotalPage) {
            console.log("dodaje strone :)")
            PageNumber = PageNumber + 1;
        }
        
        LoadDishService(PageNumber)
    });

    $("#dish-page-down").click(function () {
        if (PageNumber === 1) {
            PageNumber = 1
        }
        else {
            PageNumber = PageNumber - 1;
        }
        LoadDishService(PageNumber)
    });

});

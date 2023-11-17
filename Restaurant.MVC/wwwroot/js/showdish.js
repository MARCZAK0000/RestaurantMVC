const currentScriptGetDish = document.currentScript;


$(document).ready(function () {


    const PageSize = 10;
    let PageNumber = 1;

    $("#dish-page-up").click(function () {
        PageNumber = PageNumber + 1;
    });

    $("#dish-page-down").click(function () {
        if (PageNumber === 1) {
            PageNumber = 1
        }
        else {
            PageNumber = PageNumber - 1;
        }
    });

    
    const RenderCarWorkshopServices = (items) => {
        const TotalItems = items.Length;
        const ItemsFrom = PageSize * (PageNumber - 1) + 1;
        const ItemsTo = (PageSize * (PageNumber - 1) + 1) + PageSize - 1;
        console.log(items);
    }



    const LoadDishService = () => {
        const encodeName = currentScriptGetDish.getAttribute('data-encodedName');
        const url = `https://localhost:7152/Restaurant/${encodeName}/Dish`;
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



    LoadDishService();



});

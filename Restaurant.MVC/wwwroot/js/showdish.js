const currentScriptGetDish = document.currentScript;


$(document).ready(function () {
    let TotalPage = 0;
    const PageSize = 1;
    let PageNumber = 1;
    const RenderCarWorkshopServices = (items) => {
        const TotalItems = items.Length;
        TotalPage = items.totalItems % PageSize == 0 ? items.totalItems / PageSize : (items.totalItems /PageSize)+1
        const ItemsFrom = PageSize * (PageNumber - 1) + 1;
        const ItemsTo = (PageSize * (PageNumber - 1) + 1) + PageSize - 1;
        console.log(items);
        console.log(TotalPage);


        items.items.Length>0?
            $("#dish-servivces-container").append
            :
            $("dish-service")
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

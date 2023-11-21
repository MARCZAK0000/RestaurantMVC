const CurrentRestaurantScript = document.currentScript
$(document).ready(function () {
    
    CurrentRestaurantEncodedName = CurrentRestaurantScript.getAttribute("data-encodedName");
    $(document).on("click", ".dish-edit-service", function () {
        let EncodedName = $(this).attr("data-encodedName")
        const url = `https://localhost:7152/Restaurant/${CurrentRestaurantEncodedName}/Dish/${EncodedName}`


        let newPrice = 0;
        const RenderModalBody = (data) => {
            console.log(data)
            $(".modal-body").html(
                `
                <form>
                    <div class="form-floating mb-3">
                        <input asp-for="Name" type="text" class="form-control" disabled  value = "${data.name}"/>
                        <label asp-for="Name">Dish Name</label>
                    </div>
                    <div class="form-floating mb-3">
                        <input for="Describition" type="text" class="form-control" disabled value = "${data.describition}" />
                        <label for="Describition">Description</label>
                    </div>
                    <div class="form-floating mb-3">
                        <input for="Price" type="text" class="form-control" disabled value = "${data.price}" />
                        <label for="Price">Price</label>
                    </div>

                    <div class="form-floating mb-3">
                        <input id="edit-dish-price" for="NewPrice" type="number" min="0" max="300" step="0.50" class="form-control" />
                        <label for="NewPrice">New Price</label>
                    </div>
                </form>
                `
            )
           
        }
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                RenderModalBody(data)
                $("#editDishModal").modal(
                    'show'
                );
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })

        
        $(document).on("click", "#dish-edit-save", function () {
            const responseBody = {
                price: newPrice
            }

            $.ajax({
                type: "PUT",
                url: url,
                data: JSON.stringify(responseBody),
                contentType: 'application/json',
                success: function (data) {
                    toastr["success"](`${data.message}`)
                },
                error: function (data) {
                    toastr["success"]("Something went wrong")
                }

            })
        });

        $(document).on("change", "#edit-dish-price", function () {
            newPrice = $(this).val()
            console.log(newPrice)
        })

    });
})
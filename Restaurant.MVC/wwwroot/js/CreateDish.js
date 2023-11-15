const dishSave = document.querySelector('#dish-save');
const dishName = document.querySelector('#dish-name');
const dishDescribtion = document.querySelector('#dish-describition');
const dishPrice = document.querySelector('#dish-price');
const currentScript = document.currentScript;
const restaurantDishesContainer = document.querySelector('#restaurant-dishes') 


const url = 'https://localhost:7152/Restaurant'


//Events
dishSave.addEventListener('click', () => {
    const responseBody = {
        Name: dishName.value,
        Describition: dishDescribtion.value,
        Price : dishPrice.value
    }
    const encodedName = currentScript.getAttribute('data-encodedName');


    CreateDish(`${url}/${encodedName}/Edit/Dish`, responseBody);


})




const renderHtml = async () => {

    const encodedName = currentScript.getAttribute('data-encodedName');
    const response = await GetDishes(`${url}/${encodedName}/Edit/Dish`)


    if (resonse === null || response === undefined) {
        restaurantDishesContainer.innerHTML = `<div class = "container text-center" >There is no dishes in restaurant</div>`
    }
    if (response.length >= 1) {
        restaurantDishesContainer.innerHTML = `<div>Hello</div>`
    }
}













//methods
const CreateDish = async (url, body) => {

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body)
        });
        if (!response.ok) {
            toastr["error"]("Something Went Wrong")
            throw new Error("Error")
        }

        toastr["success"]("Good")
    }
   
    catch (err) {
            console.error(err)
        }
    
}


const GetDishes = async (url) => {
    try {
        const response = await fetch(url, {
            method: 'GET'
        })

        if (!response.ok) {
            throw new Error('Something went wrong')
        }

        const result = response.json();
        return result
        
    }
    catch (err) {
        toastr["error"](err)
    }
}



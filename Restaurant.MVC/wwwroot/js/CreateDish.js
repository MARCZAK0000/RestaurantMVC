const dishSave = document.querySelector('#dish-save');
const dishName = document.querySelector('#dish-name');
const dishDescribtion = document.querySelector('#dish-describition');
const dishPrice = document.querySelector('#dish-price');
const url = 'https://localhost:7152/'


dishSave.addEventListener('click', () => {
    const responseBody = {
        Name: dishName.value,
        Describition: dishDescribtion.value,
        Price : dishPrice.value
    }

    
})


const CreateDish = async (url, body) => {
    const response = await fetch(url, {
        method: 'POST',
        body: JSON.stringify(body)
    })
}



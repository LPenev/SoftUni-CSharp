const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const foodInput = document.getElementById('food');
const timeInput = document.getElementById('time');
const caloriesInput = document.getElementById('calories');

const addMealBtn = document.getElementById('add-meal');
const editMealBtn = document.getElementById('edit-meal');
const loadMealsBtn = document.getElementById('load-meals');

const mealsList = document.getElementById('list');

loadMealsBtn.addEventListener('click', loadMeals);
addMealBtn.addEventListener('click', addMeal);
editMealBtn.addEventListener('click',e => updateMeal(currentId));

async function loadMeals(){
    mealsList.innerHTML = '';
    editMealBtn.disabled = true;

    try{
        const response = await fetch(baseUrl);
        
        if(!response.ok){
            throw('Response error.');
        }
        
        const data = await response.json();
        const meals = Object.values(data);
        meals.forEach(meal => displayMeal(meal));

    }catch(error){
        console.dir(error);
    }
}

function displayMeal(meal){

    const mealDiv = document.createElement('div');
    mealDiv.classList.add('meal');
    const foodH2 = document.createElement('h2');
    foodH2.textContent = meal.food;
    const timeH3 = document.createElement('h3');
    timeH3.textContent = meal.time;
    const calorieH3 = document.createElement('h3');
    calorieH3.textContent = meal.calories;
    
    mealDiv.appendChild(foodH2);
    mealDiv.appendChild(timeH3);
    mealDiv.appendChild(calorieH3);

    const mealButtonsDiv = document.createElement('div');
    mealButtonsDiv.classList.add('meal-buttons');
    const changeBtn = document.createElement('button');
    changeBtn.textContent = 'Change';
    changeBtn.classList.add('change-meal');
    changeBtn.id = 'change-meal';
    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.classList.add('delete-meal');
    deleteBtn.id = 'delete-meal';

    changeBtn.addEventListener('click', e => populateMeal(mealDiv, meal));
    deleteBtn.addEventListener('click', e => deleteMeal(mealDiv, meal._id));

    mealButtonsDiv.appendChild(changeBtn);
    mealButtonsDiv.appendChild(deleteBtn);
    mealDiv.appendChild(mealButtonsDiv);
    mealsList.appendChild(mealDiv);
}

function deleteMeal(container, mealId){
    try{
        fetch(baseUrl + `/${mealId}`,
        {
            method: 'DELETE'
        });
        const myTimeout = setTimeout(loadMeals, 10);

        container.remove();
    
    } catch (error) {
        console.error("Error deleting workout:", error);
    }
}

async function addMeal(){
    const food = foodInput.value;
    const time = timeInput.value;
    const calories = caloriesInput.value;

    if(!food || !time || !calories){
        alert('Please fill out all fields!');
    }

    const MealObj = {food, time, calories};
    try{
        await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'aplication/json'},
            body: JSON.stringify(MealObj)
        });
    }catch(error){
        console.dir(error);
    }   

    clearInputFelds();
    loadMeals();
} 

function clearInputFelds(){
    foodInput.value = '';
    timeInput.value = '';
    caloriesInput.value = '';
}

function populateMeal(container, meal){
    
    clearInputFelds();

    foodInput.value = meal.food;
    timeInput.value = meal.time;
    caloriesInput.value = meal.calories;


    editMealBtn.disabled = false;
    addMealBtn.disabled = true;
    currentId = meal._id;
    //container.remove();
}

function updateMeal(id){

    if(!id){
        throw new Error('missind Id by update Meal.');
    }
    
    const food = foodInput.value;
    const time = timeInput.value;
    const calories = caloriesInput.value;
    
    if(!food || !time || !calories){
        alert('Please fill out all fields!');
    }

    const mealObj = {
        food, time, calories, _id: id
    }
    
    try{
        fetch(baseUrl + `/${id}`,{
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(mealObj)
        });

        editMealBtn.disabled = true;
        addMealBtn.disabled = false;
        currentId = null;

    }catch(error){
        console.dir(error);
    }
    clearInputFelds();
    const myTimeout = setTimeout(loadMeals, 10);
}
const BASE_URL = "http://localhost:3030/jsonstore/workout/";

const loadBtn = document.getElementById("load-workout");
const addBtn = document.getElementById("add-workout");
const editBtn = document.getElementById("edit-workout");

const workoutInput = document.getElementById("workout");
const locationInput = document.getElementById("location");
const dateInput = document.getElementById("date");

const listContainer = document.getElementById("list");
let currentWorkoutId = null;

loadBtn.addEventListener("click", loadWorkouts);
addBtn.addEventListener("click", addWorkout);
editBtn.addEventListener("click", editWorkout);

async function loadWorkouts() {
    listContainer.innerHTML = '';

    try {
        const response = await fetch(BASE_URL);
        const data = await response.json();

        Object.values(data).forEach(w => dysplayWorkout(w));
    } catch (error) {
        console.error("Error loading workouts:", error);
    }
}

function dysplayWorkout(workoutData) {
    const container = document.createElement("div");
    container.classList.add("container");

    const title = document.createElement("h2");
    title.textContent = workoutData.workout;

    const date = document.createElement("h3");
    date.textContent = workoutData.date;

    const location = document.createElement("h3");
    location.id = "location";
    location.textContent = workoutData.location;

    const buttonsContainer = document.createElement("div");
    buttonsContainer.id = "buttons-container";

    const changeBtn = document.createElement("button");
    changeBtn.textContent = "Change";
    changeBtn.classList.add("change-btn");
    changeBtn.addEventListener("click", () => populateWorkoutForEdit(workoutData, container));

    const deleteBtn = document.createElement("button");
    deleteBtn.textContent = "Done";
    deleteBtn.classList.add("delete-btn");
    deleteBtn.addEventListener("click", () => deleteWorkout(workoutData._id, container));

    // add buttons
    buttonsContainer.appendChild(changeBtn);
    buttonsContainer.appendChild(deleteBtn);

    // add elements to Container
    container.appendChild(title);
    container.appendChild(date);
    container.appendChild(location);
    container.appendChild(buttonsContainer);

    // append container
    listContainer.appendChild(container);
}

async function addWorkout() {
    const workout = workoutInput.value;
    const location = locationInput.value;
    const date = dateInput.value;

    if (!workout || !location || !date) {
        alert("Please fill out all fields!");
        return;
    }

    const workoutObj = { workout, location, date };

    try {
        await fetch(BASE_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(workoutObj),
        });

        clearInputs();
        loadWorkouts();
    } catch (error) {
        console.error("Error adding workout:", error);
    }
}

function populateWorkoutForEdit(workoutData, container) {
    currentWorkoutId = workoutData._id;
    workoutInput.value = workoutData.workout;
    locationInput.value = workoutData.location;
    dateInput.value = workoutData.date;

    addBtn.disabled = true;
    editBtn.disabled = false;

    container.remove();
}

async function editWorkout() {
    const workout = workoutInput.value;
    const location = locationInput.value;
    const date = dateInput.value;
    
    if (!workout || !location || !date) {
        alert("Please fill out all fields!");
        return;
    }
    
    if(!currentWorkoutId){
        throw('Error no workout Id.');
    }
    
    const workoutObj = { workout, location, date, _id: currentWorkoutId };

    try {
        
        await fetch(`${BASE_URL}${currentWorkoutId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(workoutObj),
        });

        clearInputs();
        loadWorkouts();

        addBtn.disabled = false;
        editBtn.disabled = true;
        currentWorkoutId = null;
    
    } catch (error) {
        console.error("Error editing workout:", error);
    }
}

async function deleteWorkout(id, container) {
    try {
        await fetch(`${BASE_URL}${id}`, {
            method: "DELETE",
        });

        container.remove();
    } catch (error) {
        console.error("Error deleting workout:", error);
    }
}

function clearInputs() {
    workoutInput.value = "";
    locationInput.value = "";
    dateInput.value = "";
}

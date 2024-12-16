window.addEventListener("load", solve);

function solve() {
    const emailInput = document.getElementById("email");
    const eventInput = document.getElementById("event");
    const locationInput = document.getElementById("location");
    const nextButton = document.getElementById("next-btn");
    const previewList = document.getElementById("preview-list");
    const eventList = document.getElementById("event-list");

    nextButton.addEventListener("click", () => {
        const email = emailInput.value.trim();
        const event = eventInput.value.trim();
        const location = locationInput.value.trim();

        // Do nothing if any field is empty
        if (!email || !event || !location) {
            console.dir('email, event or location is empty...');
            return;
        }

        // Create the list item
        const li = document.createElement("li");
        li.className = "application";

        const article = document.createElement("article");

        const emailElement = document.createElement("h4");
        const emailStrong = document.createElement("strong");
        emailStrong.textContent = "Email:";
        emailElement.appendChild(emailStrong);
        const emailBreak = document.createElement("br");
        emailElement.appendChild(emailBreak);
        emailElement.appendChild(document.createTextNode(email));

        const eventElement = document.createElement("p");
        const eventStrong = document.createElement("strong");
        eventStrong.textContent = "Event:";
        eventElement.appendChild(eventStrong);
        const eventBreak = document.createElement("br");
        eventElement.appendChild(eventBreak);
        eventElement.appendChild(document.createTextNode(event));

        const locationElement = document.createElement("p");
        const locationStrong = document.createElement("strong");
        locationStrong.textContent = "Location:";
        locationElement.appendChild(locationStrong);
        const locationBreak = document.createElement("br");
        locationElement.appendChild(locationBreak);
        locationElement.appendChild(document.createTextNode(location));

        article.appendChild(emailElement);
        article.appendChild(eventElement);
        article.appendChild(locationElement);
        li.appendChild(article);

        // Add Edit button
        const editButton = document.createElement("button");
        editButton.className = "action-btn";
        editButton.textContent = "Edit";
        editButton.addEventListener("click", () => {
            emailInput.value = email;
            eventInput.value = event;
            locationInput.value = location;

            li.remove();
            nextButton.disabled = false;
        });

        // Add Apply button
        const applyButton = document.createElement("button");
        applyButton.className = "action-btn";
        applyButton.textContent = "Apply";
        applyButton.addEventListener("click", () => {
            editButton.remove();
            applyButton.remove();
            eventList.appendChild(li);
            nextButton.disabled = false;
        });

        li.appendChild(editButton);
        li.appendChild(applyButton);

        // Add the new list item to the preview list
        previewList.appendChild(li);

        // Clear input fields
        emailInput.value = "";
        eventInput.value = "";
        locationInput.value = "";

        // Disable Next button
        nextButton.disabled = true;
    });
}
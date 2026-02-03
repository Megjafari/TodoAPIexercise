const apiUrl = "https://localhost:7158/api/items"; // ✅ din backend

async function loadTodos() {
    const res = await fetch(apiUrl);
    const todos = await res.json();

    const list = document.getElementById("todoList");
    list.innerHTML = "";

    todos.forEach(todo => {
        const li = document.createElement("li");

        const span = document.createElement("span");
        span.textContent = `ID: ${todo.id} - ${todo.title}`;
        if (todo.isDone) span.classList.add("done");

        const buttonsDiv = document.createElement("div");
        buttonsDiv.className = "action-buttons";

        // Markera klar
        const doneBtn = document.createElement("button");
        doneBtn.textContent = "✔";
        doneBtn.className = "done-btn";
        doneBtn.onclick = () => toggleDone(todo);

        // Redigera
        const editBtn = document.createElement("button");
        editBtn.textContent = "✏️";
        editBtn.onclick = () => editTodo(todo);

        // Ta bort
        const delBtn = document.createElement("button");
        delBtn.textContent = "🗑";
        delBtn.className = "delete";
        delBtn.onclick = () => deleteTodo(todo.id);

        buttonsDiv.appendChild(doneBtn);
        buttonsDiv.appendChild(editBtn);
        buttonsDiv.appendChild(delBtn);

        li.appendChild(span);
        li.appendChild(buttonsDiv);
        list.appendChild(li);
    });
}

async function addTodo() {
    const title = document.getElementById("titleInput").value;
    if (!title) return alert("Enter a title");

    await fetch(apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ title, isDone: false })
    });

    document.getElementById("titleInput").value = "";
    loadTodos();
}

async function deleteTodo(id) {
    await fetch(`${apiUrl}/${id}`, { method: "DELETE" });
    loadTodos();
}

async function toggleDone(todo) {
    console.log("Before toggle:", todo);

    const response = await fetch(`${apiUrl}/${todo.id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            id: todo.id,
            title: todo.title,
            isDone: !todo.isDone
        })
    });

    console.log("PUT status:", response.status);

    await loadTodos();
}


function editTodo(todo) {
    const newTitle = prompt("Edit title:", todo.title);
    if (!newTitle) return;

    fetch(`${apiUrl}/${todo.id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ id: todo.id, title: newTitle, isDone: todo.isDone })
    }).then(loadTodos);
}

// Ladda alla todos direkt när sidan öppnas
loadTodos();

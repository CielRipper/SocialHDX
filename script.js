const sampleEvents = [
    {
        id: 1,
        title: "Yoga Class",
        tag: "Wellness",
        date: "April 25, 2026",
        time: "5:00 PM",
        location: "Student Center"
    },
    {
        id: 2,
        title: "Art Workshop",
        tag: "Arts",
        date: "April 26, 2026",
        time: "3:00 PM",
        location: "Fine Arts Building"
    },
    {
        id: 3,
        title: "Basketball Game",
        tag: "Sports",
        date: "April 27, 2026",
        time: "7:00 PM",
        location: "Gymnasium"
    },
    {
        id: 4,
        title: "Club Fair",
        tag: "Social",
        date: "April 28, 2026",
        time: "1:00 PM",
        location: "Campus Lawn"
    },
    {
        id: 5,
        title: "Study Skills Seminar",
        tag: "Academic",
        date: "April 29, 2026",
        time: "11:00 AM",
        location: "Library"
    },
    {
        id: 6,
        title: "Movie Night",
        tag: "Social",
        date: "April 30, 2026",
        time: "8:00 PM",
        location: "Residence Hall Lounge"
    }
];

function renderEvents(events) {
    const container = document.getElementById("eventsContainer");

    if (!container) return; // prevents errors on other pages

    container.innerHTML = "";

    events.forEach(event => {
        container.innerHTML += `
            <div class="col-md-6 col-lg-4">
                <div class="card p-3 mb-3">
                    <h5>${event.title}</h5>
                    <p><strong>Tag:</strong> ${event.tag}</p>
                    <p><strong>Date:</strong> ${event.date}</p>
                    <p><strong>Time:</strong> ${event.time}</p>
                    <p><strong>Location:</strong> ${event.location}</p>
                </div>
            </div>
        `;
    });
}

function setupFilters() {
    const buttons = document.querySelectorAll(".filter-chip");

    if (!buttons.length) return;

    buttons.forEach(button => {
        button.addEventListener("click", () => {
            const tag = button.textContent.trim();

            if (tag === "All") {
                renderEvents(sampleEvents);
                return;
            }

            const filtered = sampleEvents.filter(event => event.tag === tag);
            renderEvents(filtered);
        });
    });
}

function setupPrescriptionForm() {
    const submitBtn = document.querySelector(".btn-submit-prescription");

    if (!submitBtn) return;

    submitBtn.addEventListener("click", () => {
        const firstName = document.getElementById("firstName").value.trim();
        const lastName = document.getElementById("lastName").value.trim();
        const email = document.getElementById("email").value.trim();
        const studentId = document.getElementById("studentId").value.trim();
        const notes = document.getElementById("notes").value.trim();

        if (!firstName || !lastName || !email || !studentId || !notes) {
            alert("Fill in all fields");
            return;
        }

        const prescription = {
            id: Date.now(),
            firstName,
            lastName,
            email,
            studentId,
            notes
        };

        let stored = JSON.parse(localStorage.getItem("prescriptions")) || [];
        stored.push(prescription);

        localStorage.setItem("prescriptions", JSON.stringify(stored));

        alert("Prescription saved");

        document.getElementById("firstName").value = "";
        document.getElementById("lastName").value = "";
        document.getElementById("email").value = "";
        document.getElementById("studentId").value = "";
        document.getElementById("notes").value = "";
    });
}

document.addEventListener("DOMContentLoaded", () => {
    renderEvents(sampleEvents);
    setupFilters();
    setupPrescriptionForm();
});
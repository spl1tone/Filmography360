// For DropDownMenu

const navigationText = document.getElementById('navigationText');
const dropdownContent = document.querySelector('.dropdown-content');

navigationText.addEventListener('mouseenter', () => {
  dropdownContent.classList.add('visible');
});

dropdownContent.addEventListener('mouseleave', () => {
  dropdownContent.classList.remove('visible');
});

// ---

// Use Field by press '/'
const searchInput = document.getElementById('search-input');

document.addEventListener('keydown', (event) => {
  if (event.key === '/') {
    searchInput.focus();
    event.preventDefault(); // stop input '/' to field
  }
});

// ---

const themeToggle = document.getElementById('themeText');
const themeLink = document.getElementById('theme-link');


themeToggle.addEventListener('click', function (e) {
    e.preventDefault();

    const currentTheme = themeLink.getAttribute('href');

    if (currentTheme === '/css/indexDarkStyle.css') {
        themeLink.setAttribute('href', '/css/indexLightStyle.css');
    } else {
        themeLink.setAttribute('href', '/css/indexDarkStyle.css');
    }
});

// ---

document.addEventListener("DOMContentLoaded", function () {
    var searchInput = document.getElementById("search-input");
    var filmContainers = document.querySelectorAll(".film");


    function updateDisplay() {
        var searchText = searchInput.value.toLowerCase();
        var visibleCount = 0;

        filmContainers.forEach(function (filmContainer) {
            var filmName = filmContainer.querySelector("#film-name").textContent.toLowerCase();
            var shouldBeVisible = searchText === "" || filmName.includes(searchText);

            if (shouldBeVisible) {
                filmContainer.style.display = "inline-block";
                visibleCount++;
            } else {
                filmContainer.style.display = "none";
            }

            if (visibleCount % 5 === 0) {
                filmContainer.style.clear = "left";
            } else {
                filmContainer.style.clear = "none";
            }
        });
    }

    searchInput.addEventListener("input", updateDisplay);

    updateDisplay();
});
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
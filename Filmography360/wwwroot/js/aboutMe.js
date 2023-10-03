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
const themeLink1 = document.getElementById('theme-link1');

themeToggle.addEventListener('click', function (e) {
    e.preventDefault();

    const currentTheme = themeLink.getAttribute('href');
    const currentTheme1 = themeLink1.getAttribute('href');

    if (currentTheme === '/css/aboutMeStyleDark.css' && currentTheme1 === '/css/indexDarkStyle.css') {
        themeLink.setAttribute('href', '/css/aboutMeStyleLight.css');
        themeLink1.setAttribute('href', '/css/indexLightStyle.css');
    } else {
        themeLink.setAttribute('href', '/css/aboutMeStyleDark.css');
        themeLink1.setAttribute('href', '/css/indexDarkStyle.css');
    }
});
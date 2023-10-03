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
const themeLinkIndex = document.getElementById('theme-link');
const themeLinkAbout = document.getElementById('theme-link1');

themeToggle.addEventListener('click', function (e) {
    e.preventDefault();

    const currentThemeIndex = themeLinkIndex.getAttribute('href');
    const currentThemeAbout = themeLinkAbout.getAttribute('href');

    if (currentThemeAbout === '/css/aboutMeStyleDark.css' && currentThemeIndex === '/css/indexDarkStyle.css') {
        themeLinkAbout.setAttribute('href', '/css/aboutMeStyleLight.css');
        themeLinkIndex.setAttribute('href', '/css/indexLightStyle.css');
    } else {
        themeLinkAbout.setAttribute('href', '/css/aboutMeStyleDark.css');
        themeLinkIndex.setAttribute('href', '/css/indexDarkStyle.css');
    }
});
const biographyButton = document.querySelector('.biography-button');

const biographyText = document.querySelector('.actor-biography');

biographyButton.addEventListener('click', () => {
    biographyText.classList.toggle('hidden');
});

// ---

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
const themeLinkActor = document.getElementById('theme-link1');

themeToggle.addEventListener('click', function (e) {
    e.preventDefault();

    const currentThemeIndex = themeLinkIndex.getAttribute('href');
    const currentThemeActor = themeLinkActor.getAttribute('href');

    if (currentThemeActor === '/css/actorInfoStyleDark.css' && currentThemeIndex === '/css/indexDarkStyle.css') {
        themeLinkActor.setAttribute('href', '/css/actorInfoStyleLight.css');
        themeLinkIndex.setAttribute('href', '/css/indexLightStyle.css');
    } else {
        themeLinkActor.setAttribute('href', '/css/actorInfoStyleDark.css');
        themeLinkIndex.setAttribute('href', '/css/indexDarkStyle.css');
    }
});
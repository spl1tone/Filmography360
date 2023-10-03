const factsButton = document.querySelector('.facts-button');
const reasonsButton = document.querySelector('.reasons-button');
const descriptionButton = document.querySelector('.description-button');

const factsText = document.querySelector('.film-facts');
const reasonsText = document.querySelector('.film-reasonstolook');
const descriptionText = document.querySelector('.film-description');


factsButton.addEventListener('click', () => {
    factsText.classList.toggle('hidden');
    reasonsText.classList.add('hidden'); 
    descriptionText.classList.add('hidden'); 
});

reasonsButton.addEventListener('click', () => {
    reasonsText.classList.toggle('hidden'); 
    factsText.classList.add('hidden'); 
    descriptionText.classList.add('hidden'); 
});

descriptionButton.addEventListener('click', () => {
    descriptionText.classList.toggle('hidden');
    factsText.classList.add('hidden');
    reasonsText.classList.add('hidden');
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
const themeLinkFilm = document.getElementById('theme-link1');

themeToggle.addEventListener('click', function (e) {
    e.preventDefault();

    const currentThemeIndex = themeLinkIndex.getAttribute('href');
    const currentThemeFilm = themeLinkFilm.getAttribute('href');

    if (currentThemeFilm === '/css/filmInfoStyleDark.css' && currentThemeIndex === '/css/indexDarkStyle.css') {
        themeLinkFilm.setAttribute('href', '/css/filmInfoStyleLight.css');
        themeLinkIndex.setAttribute('href', '/css/indexLightStyle.css');
    } else {
        themeLinkFilm.setAttribute('href', '/css/filmInfoStyleDark.css');
        themeLinkIndex.setAttribute('href', '/css/indexDarkStyle.css');
    }
});
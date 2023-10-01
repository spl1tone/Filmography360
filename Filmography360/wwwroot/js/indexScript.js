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
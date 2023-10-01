const biographyButton = document.querySelector('.biography-button');

const biographyText = document.querySelector('.actor-biography');

biographyButton.addEventListener('click', () => {
    biographyText.classList.toggle('hidden');
});
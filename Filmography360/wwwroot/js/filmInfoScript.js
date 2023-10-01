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
console.log(document.getElementById("modelData").textContent);
let data = JSON.parse(document.getElementById("modelData").textContent);
let back = document.getElementById("back-to-deck").getAttribute("href")
let cards = data.$values;

let container = document.querySelector(".card-container");
let counter = document.getElementById("cards-counter");
let choices = document.getElementById("container-choices")

let index = 0;
let know = 0;
let n = cards.length;
let usedNumbers = [];

StartRound(index);

async function PressKnow(i, element) {
    if (cards[index].frontText == i) {
        know++;
        $(element).find('.card-front').css('background-color', '#19e372');
    }
    else {
        $(element).find('.card-front').css('background-color', '#e74930');
    }
    await new Promise(resolve => setTimeout(resolve, 300));
    index++;
    if (index < n) {
        let card = cards[index];
        let backImage = card.backPictureUrl
            ? `<img src="/uploads/${card.backPictureUrl}" class="card-img" loading="lazy">`
            : "";

        container.innerHTML = `
            <div class="card-inner">
                <div class="card-front d-flex flex-column">
                    ${backImage}
                    <div class="card-text-box">
                        <p class="card-text">${card.backText}</p>
                    </div>
                </div>
            </div>
        `;
        counter.innerHTML = `
            ${index + 1}/${n}
        `;
        StartRound(index);
    }
    else {
        let container2 = document.querySelector("#cards-container");

        container2.innerHTML = `
            <div class="d-flex flex-column justify-content-center align-items-center">
                <h1 class>${know}/${n}</h1>
                <a class="btn btn-light" id="back-to-deck" href="${back}">Back to Deck</a>
            </div>
        `;
    };
}

function StartRound(realNumber) {
    choices.innerHTML = ""
    usedNumbers.push(realNumber)
    let when = Math.floor(Math.random() * 4);
    for (let i = 0; i < 4; i++) {
        if (when == i) {
            createChoice(realNumber);
        } else {
            let number = Math.floor(Math.random() * n);
            while (usedNumbers.includes(number)) {
                number = Math.floor(Math.random() * n);
            }
            usedNumbers.push(number);
            createChoice(number);
        }
    }
    usedNumbers = [];
}

function createChoice(i) {
    let picture = cards[i].frontPictureUrl
        ? `<img src="/uploads/${cards[i].frontPictureUrl}" class="card-img" loading="lazy">`
        : "";
    choices.innerHTML += `
    <div class="card-container-choice" onclick="PressKnow('${cards[i].frontText}', this)">
        <div class="card-inner">
            <div class="card-front d-flex flex-column">
                ${picture}
                <div class="card-text-box">
                    <p class="card-text-choice">${cards[i].frontText}</p>
                </div>
            </div>
        </div>
    </div>
    `
}
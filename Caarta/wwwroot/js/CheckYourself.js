console.log(document.getElementById("modelData").textContent);
let data = JSON.parse(document.getElementById("modelData").textContent);
let back = document.getElementById("back-to-deck").getAttribute("href")
let cards = data.$values;

let container = document.querySelector(".card-container");
let counter = document.querySelector("#cards-counter");

let index = 0;
let know = 0;
let n = cards.length;

function PressKnow(doKnow) {
    index++;
    know += doKnow ? 1 : 0;
    if (index < n) {
        let card = cards[index];
        let frontImage = card.frontPictureUrl
            ? `<img src="/uploads/${card.frontPictureUrl}" class="card-img">`
            : "";

        let backImage = card.backPictureUrl
            ? `<img src="/uploads/${card.backPictureUrl}" class="card-img">`
            : "";

        container.innerHTML = `
            <div class="card-inner">
                <div class="card-front d-flex flex-column">
                    ${frontImage}
                    <div class="card-text-box">
                        <p class="card-text">${card.frontText}</p>
                    </div>
                </div>
                <div class="card-back d-flex flex-column">
                    ${backImage}
                    <div class="card-text-box">
                        <p class="card-text">${card.backText}</p>
                    </div>
                </div>
            </div>
        `;
        counter.innerHTML = `
            ${index+1}/${n}
        `
    }
    else {
        let container2 = document.querySelector("#cards-container");

        container2.innerHTML = `
            <div class="d-flex flex-column justify-content-center align-items-center">
                <h1 class>${know}/${n}</h1>
                <a id="back-to-deck" href="${back}">Back to Deck</a>
            </div>
        `;
    };
}
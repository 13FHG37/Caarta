let container = document.querySelector("#cards-container")
let index = 2

function PressKnow(card) {
    container.innerHTML = `
    <button class="know-button" onclick="PressKnow(2)"><img src="~/img/NO.png" /></button>
    <div class="card-container" onclick="flipCard(this)">
        <div class="card-inner">
            <div class="card-front d-flex flex-column">
                @if (!string.IsNullOrEmpty(${card.FrontPictureUrl}))
                    {
                    <img src="~/uploads/${card.FrontPictureUrl}" class="card-img">
                }
                <div class="card-text-box">
                    <p class="card-text">${card.FrontText}</p>
                </div>
            </div>

            <div class="card-back d-flex flex-column">
                @if (!string.IsNullOrEmpty(${card.BackPictureUrl}))
                    {
                    <img src="~/uploads/${card.BackPictureUrl}" class="card-img">
                }
                <div class="card-text-box">
                    <p class="card-text">${card.BackText}</p>
                </div>
            </div>
        </div>
    </div>
    <button class="know-button" onclick="PressKnow(2)"><img src="~/img/YES.png" /></button>
    `
}
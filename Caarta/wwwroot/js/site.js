function flipCard(a) {
    a.classList.toggle('clicked');
};

function addCard() {
    let container = document.querySelector(".create-card-container");
    let index = (document.querySelector(".create-card-container").children.length) / 5
    $(container).append(
        `
        <hr/>
        <div class="form-floating mb-3">
            <input id="CreateCards_${index}__FrontText" name="CreateCards[${index}].FrontText" class="form-control">
            <label class="form-label" for="CreateCards_${index}__FrontText" >Front Text</label>
        </div>
        <div class="mb-3">
            <input type="file" class="form-control" id="customFile" accept="image/jpeg, image/png" id="CreateCards_${index}__FrontPicture" name="CreateCards[${index}].FrontPicture" />
        </div>
        <div class="form-floating mb-3">
            <input id="CreateCards_${index}__BackText" name="CreateCards[${index}].BackText" class="form-control">
            <label class="form-label" for="CreateCards_${index}__BackText" >Front Text</label>
        </div>
        <div class="mb-3">
            <input type="file" class="form-control" id="customFile" accept="image/jpeg, image/png" id="CreateCards_${index}__BackPicture" name="CreateCards[${index}].FrontPicture" />
        </div>`
    )
}

function ChooseGamemode(deckId, n) {
    console.log(deckId, n)
    let container = document.querySelector("body");
    let existingModal = document.getElementById("gamemode-popup");
    if (existingModal) {
        existingModal.remove();
    }

    let test = n >= 4
        ? ` <button onclick="window.location.href='/Decks/Test/${deckId}'" type="button" class="btn btn-primary">Test</button>
        <button onclick="window.location.href='/Decks/TestReversed/${deckId}'" type="button" class="btn btn-primary">Test Reversed</button>`
        : "";
    $(container).append(
        `
        <div class="modal" id="gamemode-popup" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Start Game</h5>
                    </div>
                    <div class="modal-body">
                        <p>Choose gamemode:</p>
                    </div>
                    <div class="modal-footer d-flex justify-content-between w-100">
                        <div>
                            <button onclick="window.location.href='/Decks/CheckYourself/${deckId}'" type="button" class="btn btn-primary">Check Yourself</button>
                           ${test}
                        </div>
                        <button data-bs-dismiss="modal" type="button" class="btn btn-secondary">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
        `
    )
    var modal = new bootstrap.Modal(document.getElementById("gamemode-popup"));
    modal.show();
}
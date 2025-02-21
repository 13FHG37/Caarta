function flipCard(a) {
    a.classList.toggle('clicked');
};

function addCard() {
    let container = document.querySelector(".create-card-container");
    let index = ($(container).children().length - 1) / 4;
    $(container).append(
        `
        <div class="form-group">
             <label for="Cards_${index}__FrontText">Front Text</label>
             <textarea id="Cards_${index}__FrontText" name="Cards[${index}].FrontText" class="form-control"></textarea>
         </div>
         <div class="form-group">
             <label for="Cards_${index}__FrontPicture">Front Picture</label>
             <input type="file" accept="image/jpg, image/png" id="Cards_${index}__FrontPicture" name="Cards[${index}].FrontPicture" type="file" class="form-control-file" />
         </div>
         <div class="form-group">
             <label for="Cards_${index}__BackText">Back Text</label>
             <textarea id="Cards_${index}__BackText" name="Cards[${index}].BackText" class="form-control"></textarea>
         </div>
         <div class="form-group">
             <label for="Cards_${index}__BackPicture">Back Picture</label>
             <input type="file" accept="image/jpg, image/png" id="Cards_${index}__BackPicture" name="Cards[${index}].BackPicture" type="file" class="form-control-file" />
         </div>`
    )
}

function ChooseGamemode(deckId) {
    let container = document.querySelector("body");
    $(container).append(
        `
        <div class="modal" id="gamemode-popup" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Start Game</h5>
                        <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Choose gamemode:</p>
                    </div>
                    <div class="modal-footer d-flex justify-content-between w-100">
                        <div>
                            <button onclick="window.location.href='/Decks/CheckYourself/${deckId}'" type="button" class="btn btn-primary">Check Yourself</button>
                            <button onclick="window.location.href='/Decks/CheckYourself/${deckId}'" type="button" class="btn btn-primary">Test</button>
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
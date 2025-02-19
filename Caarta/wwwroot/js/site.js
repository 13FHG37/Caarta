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
             <input id="Cards_${index}__FrontPicture" name="Cards[${index}].FrontPicture" type="file" class="form-control-file" />
         </div>
         <div class="form-group">
             <label for="Cards_${index}__BackText">Back Text</label>
             <textarea id="Cards_${index}__BackText" name="Cards[${index}].BackText" class="form-control"></textarea>
         </div>
         <div class="form-group">
             <label for="Cards_${index}__BackPicture">Back Picture</label>
             <input id="Cards_${index}__BackPicture" name="Cards[${index}].BackPicture" type="file" class="form-control-file" />
         </div>`
    )
}
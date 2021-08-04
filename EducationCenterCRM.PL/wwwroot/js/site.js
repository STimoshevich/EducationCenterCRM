    let current_page;
    let isDataChanged = false;
        $(window).on('load', function () {
        current_page = window.location.pathname;
        });



        $('button[id="add_new_button"]').click(function () {

        $.post(current_page + "/edit/", { id: 0 }, function (data, status) {
        }).done(function (result) {
            $('div[id="Info_body"]').html(result);
        });
        });


        $('button[id="info_button"]').click(function () {

        $.post(current_page + "/Details/", { id: $(this).val() }, function (data, status) {
            _data = data;
        }).done(function (result) {
            $('div[id="Info_body"]').html(result);
        });
        });

        $('button[id="edit_button"]').click(function () {

        $.post(current_page + "/edit/", { id: $(this).val() }, function (data, status) {
            _data = data;
        }).done(function (result) {
            $('div[id="Info_body"]').html(result);
        });
        });

        $('button[id="modal_close_button"]').click(function () {
            if (isDataChanged) {
        location.reload();
            }
        });

        function removeFromList(listId,data) {
        $('ul[id="' + listId + '"]').find('li[id="' + data + '"]').remove();
        }

        //function addNewToListFromSelector(optionId,listId) {
        //    var selectedText = $('#' + optionId).find(":selected").text()
        //    var listIdToStr = "'" + listId +"'";
        //    var selectedVal = $('#' + optionId).find(":selected").val()

        //    var isContain = ($('ul[id="' + listId + '"]').find('li[id="' + selectedVal + '"]').length > 0);
        //    if (!isContain) {
        //        $('ul[id="' + listId + '"]').append(
        //            '<li class="list-group-item d-flex justify-content-between align-items-center" id="' + selectedVal + '">' +
        //            selectedText +
        //            '<button class="btn btn-primary" onclick="removeFromList(' + listIdToStr + ',' + selectedVal + ')"> Delete</button>' +
        //            '</li>'
        //        );
        //    }
        //}

        function serializeFormToObject(formId) {
            var obj = {};
            var form = $('form[id="' + formId + '"]');
            var serializedForm = form.serializeArray();

            for (var i = 0; i < serializedForm.length; i++) {
                let name = serializedForm[i].name;
                let value = serializedForm[i].value;
                obj[name] = value;
            }
            return obj;
        }

function updateByForm(formId) {
    $.validator.unobtrusive.parse($('form[id="' + formId + '"]'));
    if ($('form[id="' + formId + '"]').valid()) {
        var objForSend = serializeFormToObject(formId);
        $.post(current_page + "/updateorcreate/", { editedData: objForSend }, function (data, status) {
        }).done(function (result) {
            if (result === "") {
                location.reload();
            } else {
                $('div[id="Info_body"]').html(result);
            }
           
        });
    } 
}
function updateByFormAndList(formId, listId) {
    $.validator.unobtrusive.parse($('form[id="' + formId + '"]'));
    if ($('form[id="' + formId + '"]').valid()) {
        var objForSend = serializeFormToObject(formId);
        objForSend[listId] = serializeListToArr(listId);

        $.post(current_page + "/updateorcreate/", { editedData: objForSend }, function (data, status) {
        }).done(function (result) {
            if (result === "") {
                location.reload();
            } else {
                $('div[id="Info_body"]').html(result);
            }
        });
    }
  
}


function serializeListToArr(listId) {
    let arrOfObjects = [];

    $('ul[id="' + listId + '"]').find('li').each(function (i, x) {
        let new_obj = {};
        new_obj.id = $(this).attr('id');
        arrOfObjects.push(new_obj);
    });
    return arrOfObjects;
}
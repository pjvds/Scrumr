var $projectId;
var $sprintId;

function initBoard($pId, $sId) {
    $projectId = $pId;
    $sprintId = $sId;
}

$(function () {
    var $board = $('#board');

    // let the storystages be droppable, accepting the tasks
    $('.storystage', $board).droppable({
        accept: '#board .task',
        activeClass: 'ui-state-highlight',
        drop: function (ev, ui) {
            moveTask(ui.draggable, $(this));
        }
    });

    // let the tasks be draggable
    $('.task', $board).draggable({
        cancel: 'a.ui-icon', // clicking an icon won't initiate dragging
        revert: 'invalid', // when not dropped, the item will revert back to its initial position
        containment: 'document', // stick to the document
        helper: 'clone',
        cursor: 'move'
    });

    function moveTask($item, $target) {
        $item.fadeOut(function () {
            $item.appendTo($target).show();
        });
        $.post('/Project/MoveTask', { ProjectId: $projectId, TaskId: "00000000-0000-0000-0000-000000000002", StageId: "00000000-0000-0000-0000-000000000003" });
    }

    function showAddNewStoryDialog($projectId, $sprintId) {

    }


    var description = $("#name"),
	    email = $("#email"),
		password = $("#password"),
		allFields = $([]).add(name).add(email).add(password),
		tips = $(".validateTips");

    function updateTips(t) {
        tips
				.text(t)
				.addClass('ui-state-highlight');
        setTimeout(function () {
            tips.removeClass('ui-state-highlight', 1500);
        }, 500);
    }

    function checkLength(o, n, min, max) {

        if (o.val().length > max || o.val().length < min) {
            o.addClass('ui-state-error');
            updateTips("Length of " + n + " must be between " + min + " and " + max + ".");
            return false;
        } else {
            return true;
        }

    }

    $("#dialog-form").dialog({
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true

    });

    $('#create-new-story').button().click(function () {
        var dialog = $('#new-story-dialog');
        var button = $(this);
        dialog.dialog('option', 'position', [button.position().left, button.position().top]);
        dialog.dialog("open");
    });

    $('#new-story-dialog').dialog({
        autoOpen: false, closeOnEscape: false, draggable: false,
        buttons: {
            'Create': function () {
                $.post('/Project/AddStory', { ProjectId: $projectId, SprintId: $sprintId, Description: $('#description').val() }, function(data){
                    alert(data); // John
                }, "json");

                $(this).dialog('close');
            },
            Cancel: function () {
                $(this).dialog('close');
            }
        },
        close: function () {
            allFields.val('').removeClass('ui-state-error');
        }
    });
});
var $projectId;
var $sprintId;

function initBoard($pId, $sId) {
    $projectId = $pId;
    $sprintId = $sId;
}

$(function () {
    var $board = $('#board');

    $('#new-task-dialog').dialog({
        autoOpen: false, closeOnEscape: true, draggable: false, resizable: false,
        close: function () {
            allFields.val('').removeClass('ui-state-error');
        }
    });

    $('#new-task-ok').click(function () {
        $.post('#', { ProjectId: $projectId, SprintId: $sprintId, Description: $('#description').val() }, function (data) {
            alert(data);
            $('#new-task-dialog').dialog('close');
        }, "json");

        return false;
    });

    $('#new-task-cancel').click(function () {
        $('#new-task-dialog').dialog('close');
        return false;
    });

    $('.storystage').mouseenter(function () {
        $('#new-task').appendTo($(this));
        $('#new-task').show();
    });

    $('.storystage').mouseleave(function () {
        $('#new-task').hide();
    });

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

    $('#new-story-container').click(function () {
        $(".ui-dialog-titlebar").hide();
        var dialog = $('#new-story-dialog');
        var button = $(this);
        dialog.dialog('option', 'position', [button.position().left, button.position().top]);
        dialog.dialog('option', 'width', '50');
        dialog.dialog('open');
    });

    $('#new-story-dialog').dialog({
        autoOpen: false, closeOnEscape: true, draggable: false, resizable: false,
        close: function () {
            allFields.val('').removeClass('ui-state-error');
        }
    });

    $('#new-story-ok').click(function () {
        $.post('/Project/AddStory', { ProjectId: $projectId, SprintId: $sprintId, Description: $('#description').val() }, function (data) {
            alert(data);
            $('#new-story-dialog').dialog('close');
        }, "json");

        return false;
    });

    $('#new-story-close').click(function () {
        $('#new-story-dialog').dialog('close');
        return false;
    });
});
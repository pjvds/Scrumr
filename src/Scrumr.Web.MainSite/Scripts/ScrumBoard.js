var $projectId;
var $sprintId;

function initBoard($pId, $sId) {
    $projectId = $pId;
    $sprintId = $sId;
}

$(function () {
    var $board = $('#board');
    $('button').button();

    $('#new-task').click(function () {
        var d = $('#new-task-dialog');

        d.dialog('open');

        d.dialog('widget').position({
            of: $('#new-task'),
            my: 'center center',
            at: 'center center'
        });
    });

    $('#new-task-dialog').dialog({
        autoOpen: false, closeOnEscape: true, draggable: false, resizable: false, modal: true
    });

    $('#new-task-ok').click(function () {
        var parent = $('#new-task').parent();
        var storyAndStage = parent.attr('id').split('|');
        var storyId = storyAndStage[0];
        var stageId = storyAndStage[1];
        var description = $('#new-task-dialog #description').val();

        $.post('/Project/AddTaskToStory', { ProjectId: $projectId, SprintId: $sprintId, StageId: stageId, StoryId: storyId, Description: description }, function (data) {
            var taskId = data;
            var newTaskElement = $('#new-task-prototype').clone();
            newTaskElement.attr('id', taskId);
            newTaskElement.appendTo(parent);

            newTaskElement.children('.description')[0].innerHTML = description;

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
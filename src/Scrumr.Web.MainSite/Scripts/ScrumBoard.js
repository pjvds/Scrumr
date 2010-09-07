$(function () {
    var $board = $('#board');

    // let the stage items be droppable, accepting the story items
    $('.storystage', $board).droppable({
        accept: '#board .task',
        activeClass: 'ui-state-highlight',
        drop: function (ev, ui) {
            moveTask(ui.draggable, $(this));
        }
    });

    // let the stories items be draggable
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
        $.post('/Project/MoveTask', { ProjectId: "00000000-0000-0000-0000-000000000001", TaskId: "00000000-0000-0000-0000-000000000002", StageId: "00000000-0000-0000-0000-000000000003" });
    }
});
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
    }
});
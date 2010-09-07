$(function () {
    var $stories = $('#stories'), $stages = $('#stages');

    // let the stories items be draggable
    $('li', $stories).draggable({
        cancel: 'a.ui-icon', // clicking an icon won't initiate dragging
        revert: 'invalid', // when not dropped, the item will revert back to its initial position
        containment: 'document', // stick to the document
        helper: 'clone',
        cursor: 'move'
    });

    // let the stage items be droppable, accepting the story items
    $('li', $stages).droppable({
        accept: '#stories > li',
        activeClass: 'ui-state-highlight',
        drop: function (ev, ui) {
            moveTask(ui.draggable, $(this));
        }
    });

    // let the stories be droppable as well, accepting story items
    $stories.droppable({
        accept: '#stages li',
        activeClass: 'custom-state-active',
        drop: function (ev, ui) {
            restoreTask(ui.draggable);
        }
    });

    function moveTask($item, $target) {
        $item.fadeOut(function () {
            var $list = $target;

            $item.find('a.ui-icon-trash').remove();
            $item.appendTo($list).fadeIn(function () {
                $item.animate({ width: '48px' }).find('img').animate({ height: '36px' });
            });
        });
    }

    function restoreTask($item) {
        $item.fadeOut(function () {
            $item.find('a.ui-icon-refresh').remove();
            $item.css('width', '96px').append(trash_icon).find('img').css('height', '72px').end().appendTo($stories).fadeIn();
        });
    }
});
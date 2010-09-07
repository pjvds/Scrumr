$(function () {
    // there's the stories, Todo
    var $stories = $('#stories'), $todo = $('#todo');

    // let the stories items be draggable
    $('li', $stories).draggable({
        cancel: 'a.ui-icon', // clicking an icon won't initiate dragging
        revert: 'invalid', // when not dropped, the item will revert back to its initial position
        containment: 'document', // stick to the document
        helper: 'clone',
        cursor: 'move'
    });

    // let the todo be droppable, accepting the story items
    $todo.droppable({
        accept: '#stories > li',
        activeClass: 'ui-state-highlight',
        drop: function (ev, ui) {
            deleteImage(ui.draggable);
        }
    });

    // let the stories be droppable as well, accepting story items
    $stories.droppable({
        accept: '#todo li',
        activeClass: 'custom-state-active',
        drop: function (ev, ui) {
            recycleImage(ui.draggable);
        }
    });

    // image deletion function
    var recycle_icon = '<a href="link/to/recycle/script/when/we/have/js/off" title="Recycle this image" class="ui-icon ui-icon-refresh">Recycle image</a>';
    function deleteImage($item) {
        $item.fadeOut(function () {
            var $list = $('ul', $todo).length ? $('ul', $todo) : $('<ul class="stories ui-helper-reset"/>').appendTo($todo);

            $item.find('a.ui-icon-trash').remove();
            $item.append(recycle_icon).appendTo($list).fadeIn(function () {
                $item.animate({ width: '48px' }).find('img').animate({ height: '36px' });
            });
        });
    }

    // image recycle function
    var trash_icon = '<a href="link/to/trash/script/when/we/have/js/off" title="Delete this image" class="ui-icon ui-icon-trash">Delete image</a>';
    function recycleImage($item) {
        $item.fadeOut(function () {
            $item.find('a.ui-icon-refresh').remove();
            $item.css('width', '96px').append(trash_icon).find('img').css('height', '72px').end().appendTo($stories).fadeIn();
        });
    }
});
(function () {
    $(document).ready(function () {

        //        var scalar = 10;

        var get_random_color = function () {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var i = 0; i < 3; i++) {
                color += letters[Math.round(Math.random() * 15)];
            }
            return color;
        };
        var $cellularAutomata = $('#cellular-automata-experiment');



        function clickableGrid(rows, cols, callback) {
            var i = 0;
            var grid = document.createElement('table');
            grid.className = 'grid';
            for (var r = 0; r < rows; ++r) {
                var tr = grid.appendChild(document.createElement('tr'));
                for (var c = 0; c < cols; ++c) {
                    var cell = tr.appendChild(document.createElement('td'));
                    cell.innerHTML = '&nbsp;';
                }
            }
            return grid;
        }


        var html = clickableGrid(20, 72);

        var toggle = function () {

            if ($(this).hasClass('grid-on')) {
                $(this).removeClass('grid-on').addClass('grid-off');
            } else {
                $(this).removeClass('grid-off').addClass('grid-on');
            }



        };


        var initColors = function () {
            $(html).find('td').each(function () {
                $(this).addClass('grid-off').on('click', toggle);
            });

            $(html).find('tr').find('td:first').each(function (i, e) {

                $(this).addClass('grid-play-tone').data('note', i);
            });
        };


        var playNote = function (note) {



            var $thisNode = $('#ca-t' + (20 - note))[0];



            $thisNode.currentTime = 0;
            $thisNode.play();

        };

        var waveon = true;


        initColors();

        $cellularAutomata.prepend(html);

        var $cellularAutomataSoundbank = $('#cellular-automata-soundbank');

        var $cells = $(html).find('td');
        var wave = function () {


            if (waveon) {


                $.each($cells, function () {

                    var $target = $(this);




                    if ($target.hasClass('grid-on')) {



                        if ($target.hasClass('grid-play-tone')) {
                            $target.removeClass('grid-on');
                            playNote($(this).data('note'));
                        }

                        $target.prev().removeClass('grid-off').addClass('grid-on');
                        $target.removeClass('grid-on').addClass('grid-off');

                    }


                });

            }

        };

        $('#Zone-Billboard').prepend('<div class="wave-button-frame"><div class="w-fix w-3 w-alpha"><button class="wave-button theme-form-decoration-corners">Toggle The Sound Movement</button></div><div class="w-auto slider-shim"><br class=""/><div class="speed-slider" ></div></div></div>');

        var playbackSpeed = 180;
        var playLoop = setInterval(wave, playbackSpeed);

        $('#Zone-Billboard').find('.wave-button').button({
            text: false,
            icons: {
                primary: 'ui-icon-dashedcircle'
            }
        })
        .click(function () {

            waveon = !waveon;

            if (!waveon) {
                $(this).button({
                    icons: {
                        primary: 'ui-icon-blank'
                    }
                });
            } else {
                $(this).button({
                    icons: {
                        primary: 'ui-icon-dashedcircle'
                    }
                });
            }


        });

        var sliderTolerance = 170;

        $('#Zone-Billboard').find('.speed-slider').slider({

            value: playbackSpeed,
            range: 'min',
            min: playbackSpeed - sliderTolerance,
            max: playbackSpeed + sliderTolerance,
            step:5,
            stop: function (event, ui) {

                playbackSpeed = ui.value;

                if (playLoop) {
                    clearInterval(playLoop);
                    playLoop = setInterval(wave, playbackSpeed);
                }


            }
        });




    });


})();
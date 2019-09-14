﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Commands;
using TileGameEngine.Commands.ControlFlow;
using TileGameEngine.Commands.FileIO;
using TileGameEngine.Commands.LogicalOperators;
using TileGameEngine.Commands.Map;
using TileGameEngine.Commands.MapView;
using TileGameEngine.Commands.Math;
using TileGameEngine.Commands.Misc;
using TileGameEngine.Commands.NumericConversions;
using TileGameEngine.Commands.Sound;
using TileGameEngine.Commands.Stack;
using TileGameEngine.Commands.String;
using TileGameEngine.Commands.System;
using TileGameEngine.Commands.Variable;
using TileGameEngine.Commands.Window;
using Environment = TileGameEngine.Core.RuntimeEnvironment.Environment;

namespace TileGameEngine.Core
{
    public class CommandDictionary
    {
        private readonly Dictionary<string, CommandBase> Commands = new Dictionary<string, CommandBase>();

        private readonly Interpreter Interpreter;
        private readonly Environment Environment;

        private void InitializeCommands()
        {
            // MISC
            Set("NOP", new NopCommand());

            // CONTROL FLOW
            Set("JUMP", new JumpCommand());
            Set("JUMP.Z", new JumpZeroCommand());
            Set("JUMP.NZ", new JumpNotZeroCommand());
            Set("JUMP.EQ", new JumpEqualCommand());
            Set("JUMP.NEQ", new JumpNotEqualCommand());
            Set("JUMP.GT", new JumpGreaterThanCommand());
            Set("JUMP.GTEQ", new JumpGreaterOrEqualCommand());
            Set("JUMP.LT", new JumpLessThanCommand());
            Set("JUMP.LTEQ", new JumpLessOrEqualCommand());
            Set("CALL", new CallCommand());
            Set("CALL.Z", new CallZeroCommand());
            Set("CALL.NZ", new CallNotZeroCommand());
            Set("CALL.EQ", new CallEqualCommand());
            Set("CALL.NEQ", new CallNotEqualCommand());
            Set("CALL.GT", new CallGreaterThanCommand());
            Set("CALL.GTEQ", new CallGreaterOrEqualCommand());
            Set("CALL.LT", new CallLessThanCommand());
            Set("CALL.LTEQ", new CallLessOrEqualCommand());
            Set("RETURN", new ReturnCommand());

            // STACK
            Set("PUSH", new PushCommand());
            Set("POP", new PopCommand());
            Set("STORE", new StoreCommand());
            Set("LOAD", new LoadCommand());
            Set("DUP", new DuplicateCommand());

            // LOGICAL OPERATORS
            Set("AND", new LogicalAndCommand());
            Set("OR", new LogicalOrCommand());
            Set("XOR", new LogicalXorCommand());
            Set("NOT", new LogicalNotCommand());

            // SYSTEM
            Set("SYSTEM.EXIT", new ExitCommand());
            Set("SYSTEM.SLEEP", new SleepCommand());
            Set("SYSTEM.LOG", new LogCommand());
            Set("SYSTEM.RESET", new ResetCommand());
            Set("SYSTEM.HALT", new HaltCommand());
            Set("SYSTEM.SPEED.SET", new SpeedSetCommand());

            // MATH
            Set("MATH.INCREMENT", new IncrementCommand());
            Set("MATH.DECREMENT", new DecrementCommand());
            Set("MATH.ADD", new AddCommand());
            Set("MATH.SUBTRACT", new SubtractCommand());
            Set("MATH.COMPARE", new CompareCommand());
            Set("MATH.MULTIPLY", new MultiplyCommand());
            Set("MATH.DIVIDE", new DivideCommand());
            Set("MATH.MODULO", new ModuloCommand());
            Set("MATH.SQRT", new SquareRootCommand());
            Set("MATH.POWER", new PowerCommand());
            Set("MATH.RANDOM", new RandomCommand());

            // VARIABLES
            Set("VAR.INCREMENT", new VariableIncrementCommand());
            Set("VAR.DECREMENT", new VariableDecrementCommand());
            Set("VAR.ADD", new VariableAddCommand());
            Set("VAR.SUBTRACT", new VariableSubtractCommand());
            Set("VAR.MULTIPLY", new VariableMultiplyCommand());
            Set("VAR.DIVIDE", new VariableDivideCommand());

            // CONVERT
            Set("CONVERT.BYTE", new ConvertToByteCommand());

            // STRING
            Set("STRING.FORMAT", new StringFormatCommand());
            Set("STRING.CONCAT", new StringConcatCommand());
            Set("STRING.JOIN", new StringJoinCommand());
            Set("STRING.EQUALS", new StringEqualsCommand());
            Set("STRING.CONTAINS", new StringContainsCommand());

            // SOUND
            Set("SOUND.PLAY.ONCE", new SoundPlayOnceCommand());
            Set("SOUND.PLAY.LOOP", new SoundPlayLoopCommand());
            Set("SOUND.PLAY.AWAIT", new SoundPlayAwaitCommand());
            Set("SOUND.STOP", new SoundStopCommand());

            // FILE
            Set("FILE.CREATE", new FileCreateCommand());
            Set("FILE.DELETE", new FileDeleteCommand());
            Set("FILE.OPEN", new FileOpenCommand());
            Set("FILE.EOF", new FileEofCommand());
            Set("FILE.READ.INT", new FileReadIntCommand());
            Set("FILE.READ.SHORT", new FileReadShortCommand());
            Set("FILE.READ.CHAR", new FileReadCharCommand());
            Set("FILE.READ.BYTE", new FileReadByteCommand());
            Set("FILE.READ.STRING", new FileReadStringCommand());
            Set("FILE.READ.ALL", new FileReadAllTextCommand()); // todo: does not read cr/lf
            Set("FILE.WRITE.INT", new FileWriteIntCommand());
            Set("FILE.WRITE.SHORT", new FileWriteShortCommand());
            Set("FILE.WRITE.CHAR", new FileWriteCharCommand());
            Set("FILE.WRITE.BYTE", new FileWriteByteCommand());
            Set("FILE.WRITE.STRING", new FileWriteStringCommand()); // todo: puts 0 (null) at the end
            Set("FILE.FLUSH", new FileFlushCommand());
            Set("FILE.SEEK", new FileSeekCommand());

            // WINDOW
            Set("WINDOW.OPEN", new OpenCommand());
            Set("WINDOW.TITLE.SET", new WindowTitleSetCommand());
            Set("WINDOW.CLEAR", new ClearCommand());
            Set("WINDOW.REFRESH", new RefreshCommand());
            Set("WINDOW.PALETTE.SET", new WindowPaletteSetCommand());
            Set("WINDOW.TILESET.SET", new WindowTilesetSetCommand());
            Set("WINDOW.KEY.PRESSED", new KeyPressedCommand());
            Set("WINDOW.BG.SET", new WindowBgSetCommand());
            Set("WINDOW.BG.GET", new WindowBgGetCommand());
            Set("WINDOW.CURSOR.X.SET", new WindowCursorXSetCommand());
            Set("WINDOW.CURSOR.X.GET", new WindowCursorXGetCommand());
            Set("WINDOW.CURSOR.Y.SET", new WindowCursorYSetCommand());
            Set("WINDOW.CURSOR.Y.GET", new WindowCursorYGetCommand());
            Set("WINDOW.CURSOR.MOVE", new WindowCursorMoveCommand());
            Set("WINDOW.CURSOR.UP", new WindowCursorMoveUpCommand());
            Set("WINDOW.CURSOR.DOWN", new WindowCursorMoveDownCommand());
            Set("WINDOW.CURSOR.RIGHT", new WindowCursorMoveRightCommand());
            Set("WINDOW.CURSOR.LEFT", new WindowCursorMoveLeftCommand());
            Set("WINDOW.TILE.IX.SET", new TileIxSetCommand());
            Set("WINDOW.TILE.IX.GET", new TileIxGetCommand());
            Set("WINDOW.TILE.FG.SET", new TileFgSetCommand());
            Set("WINDOW.TILE.FG.GET", new TileFgGetCommand());
            Set("WINDOW.TILE.BG.SET", new TileBgSetCommand());
            Set("WINDOW.TILE.BG.GET", new TileBgGetCommand());
            Set("WINDOW.TILE.FILL", new TileFillCommand());
            Set("WINDOW.PRINT", new PrintCommand());

            // MAP VIEW
            Set("MAPVIEW.X.SET", new MapViewXSetCommand());
            Set("MAPVIEW.Y.SET", new MapViewYSetCommand());
            Set("MAPVIEW.WIDTH.SET", new MapViewWidthSetCommand());
            Set("MAPVIEW.HEIGHT.SET", new MapViewHeightSetCommand());
            Set("MAPVIEW.SCROLL.X.SET", new MapViewScrollXSetCommand());
            Set("MAPVIEW.SCROLL.Y.SET", new MapViewScrollYSetCommand());
            Set("MAPVIEW.SCROLL.UP", new MapViewScrollUpCommand());
            Set("MAPVIEW.SCROLL.DOWN", new MapViewScrollDownCommand());
            Set("MAPVIEW.SCROLL.RIGHT", new MapViewScrollRightCommand());
            Set("MAPVIEW.SCROLL.LEFT", new MapViewScrollLeftCommand());
            Set("MAPVIEW.SHOW", new MapViewShowCommand());
            Set("MAPVIEW.HIDE", new MapViewHideCommand());
            Set("MAPVIEW.ANIM.STOP", new MapViewAnimationStopCommand());
            Set("MAPVIEW.ANIM.START", new MapViewAnimationStartCommand());

            // MAP
            Set("MAP.LOAD", new MapLoadCommand());
            Set("MAP.FILE.GET", new MapFileGetCommand());
            Set("MAP.WIDTH.GET", new MapWidthGetCommand());
            Set("MAP.HEIGHT.GET", new MapHeightGetCommand());
            Set("MAP.NAME.SET", new MapNameSetCommand());
            Set("MAP.NAME.GET", new MapNameGetCommand());
            Set("MAP.BG.SET", new MapBgSetCommand());
            Set("MAP.PALETTE.SET", new MapPaletteSetCommand());
            Set("MAP.TILESET.SET", new MapTilesetSetCommand());
            Set("MAP.CURSOR.MOVE", new MapCursorMoveCommand());
            Set("MAP.CURSOR.LAYER.SET", new MapCursorLayerSetCommand());
            Set("MAP.CURSOR.LAYER.GET", new MapCursorLayerGetCommand());
            Set("MAP.CURSOR.X.SET", new MapCursorXSetCommand());
            Set("MAP.CURSOR.X.GET", new MapCursorXGetCommand());
            Set("MAP.CURSOR.Y.SET", new MapCursorYSetCommand());
            Set("MAP.CURSOR.Y.GET", new MapCursorYGetCommand());
            Set("MAP.CURSOR.RIGHT", new MapCursorMoveRightCommand());
            Set("MAP.CURSOR.LEFT", new MapCursorMoveLeftCommand());
            Set("MAP.CURSOR.UP", new MapCursorMoveUpCommand());
            Set("MAP.CURSOR.DOWN", new MapCursorMoveDownCommand());
            Set("MAP.CURSOR.NEXT", new MapCursorMoveNextCommand());
            Set("MAP.CURSOR.IS_VALID", new MapCursorIsValidCommand());

            // OBJECT
            Set("OBJ.CREATE", new ObjectCreateCommand());
            Set("OBJ.EXISTS", new ObjectExistsCommand());
            Set("OBJ.COPY", new ObjectCopyCommand());
            Set("OBJ.MOVE", new ObjectMoveCommand());
            Set("OBJ.UP", new ObjectMoveUpCommand());
            Set("OBJ.DOWN", new ObjectMoveDownCommand());
            Set("OBJ.RIGHT", new ObjectMoveRightCommand());
            Set("OBJ.LEFT", new ObjectMoveLeftCommand());
            Set("OBJ.SWAP", new ObjectSwapCommand());
            Set("OBJ.DELETE", new ObjectDeleteCommand());
            Set("OBJ.TAG.SET", new ObjectTagSetCommand());
            Set("OBJ.TAG.GET", new ObjectTagGetCommand());
            Set("OBJ.PROP.SET", new ObjectPropertySetCommand());
            Set("OBJ.PROP.GET", new ObjectPropertyGetCommand());
            Set("OBJ.PROP.EXISTS", new ObjectPropertyExistsCommand());
            Set("OBJ.TILE.IX.SET", new ObjectTileIxSetCommand());
            Set("OBJ.TILE.IX.GET", new ObjectTileIxGetCommand());
            Set("OBJ.TILE.FG.SET", new ObjectTileFgSetCommand());
            Set("OBJ.TILE.FG.GET", new ObjectTileFgGetCommand());
            Set("OBJ.TILE.BG.SET", new ObjectTileBgSetCommand());
            Set("OBJ.TILE.BG.GET", new ObjectTileBgGetCommand());
            Set("OBJ.FIND_TAG", new ObjectFindTagCommand());
        }

        public CommandDictionary(Interpreter interpreter, Environment environment)
        {
            Interpreter = interpreter;
            Environment = environment;
            InitializeCommands();
        }

        private void Set(string name, CommandBase command)
        {
            command.Interpreter = Interpreter;
            command.Environment = Environment;
            Commands[name] = command;
        }

        public bool HasCommand(string name)
        {
            return Commands.ContainsKey(name);
        }

        public CommandBase Get(string name)
        {
            return Commands[name];
        }
    }
}

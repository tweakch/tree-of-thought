class ArgumentProcessor
    {
        private Dictionary<string, IProblemHandler> _handlers = new Dictionary<string, IProblemHandler>
        {
            {"file", new FileAndFolderProblemHandler()},
            {"console", new ConsoleProblemHandler()}
        };

        public IProblemHandler? ChooseHandler(string[] args)
        {
            string handlerKey = args.Contains("--handler") ? args[Array.IndexOf(args, "--handler") + 1] : "file";
            return _handlers.ContainsKey(handlerKey) ? _handlers[handlerKey] : null;
        }

        public void Process(string[] args, IProblemHandler? problemHandler)
        {
            if (problemHandler == null)
            {
                Console.WriteLine("Invalid handler specified. Exiting.");
                return;
            }

            if (args[0] == "--problem" && args.Length > 1 && args.Contains("--tree-of-thought"))
            {
                string problemDescription = args[1];
                problemHandler.HandleProblem(problemDescription);

                Console.WriteLine("Processed problem description.");
            }
            else
            {
                Console.WriteLine("Invalid arguments. Exiting.");
            }
        }
    }
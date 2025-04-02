import os
import sys

#####################
# Unity
#####################
def create_unity_component(component_name, project_name, folders):
    create_file(f"{get_folder_template_by_substring(folders, 'Domain')}/{component_name}Domain.cs", get_domain_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'View')}/{component_name}View.cs", get_view_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'Adapter')}/I{component_name}Presenter.cs", get_presenter_interface_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'Factory')}/{component_name}Factory.cs", get_factory_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'Tests')}/{component_name}Tests.cs", get_unity_tests_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'Behaviours')}/{component_name}Behaviour.cs", get_behaviour_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'Behaviours')}/{component_name}InitializationBehaviour.cs", get_initialization_behaviour_template(component_name, project_name))

def get_behaviour_template(component_name, project_name):
    return \
f"""using {project_name}.{component_name}.Core.Adapter;
using UnityEngine;

namespace {project_name}.{component_name}.Unity.Behaviours
{{
    public class {component_name}Behaviour : MonoBehaviour, I{component_name}Presenter
    {{
    }}
}}
"""   

def get_initialization_behaviour_template(component_name, project_name):
    return \
f"""using {project_name}.{component_name}.Core.Factory;
using {project_name}.{component_name}.Core.Domain;
using UnityEngine;

namespace {project_name}.{component_name}.Unity.Behaviours
{{
    public class {component_name}InitializationBehaviour : MonoBehaviour
    {{
        [SerializeField]
        private {component_name}Behaviour _{component_name[0].lower() + component_name[1:]};

        private {component_name}Factory factory = new();

        private void Awake()
        {{
            Initialize();
        }}

        //This can be called either from Awake if independent or from another orchestrator script
        public {component_name}Domain Initialize()
        {{
            var domain = factory.Create(_{component_name[0].lower() + component_name[1:]});
            return domain;
        }}

        public void OnDestroy()
        {{
            factory.Clear();
        }}
    }}
}}
"""   

def get_unity_tests_template(component_name, project_name):
    return \
f"""using NUnit.Framework;
using Moq;
using {project_name}.{component_name}.Core.Domain;
using {project_name}.{component_name}.Core.Adapter;
using {project_name}.{component_name}.Core.Factory;
using {project_name}.{component_name}.Core.View;

namespace {project_name}.{component_name}.Core.Tests
{{
    [TestFixture]
    public class {component_name}Tests
    {{
        private readonly {component_name}Factory factory = new ();
        private Mock<I{component_name}Presenter> mockPresenter;

        [SetUp]
        public void SetUp()
        {{
            mockPresenter = new Mock<I{component_name}Presenter>();
        }}

        [Test]
        public void FactoryShouldCreateDomain()
        {{
            var domain = factory.Create(mockPresenter.Object);
            Assert.IsNotNull(domain);
        }}
    }}    
}}
"""

#####################
# Godot
#####################

def create_godot_component(component_name, project_name, folders):
    create_file(f"{get_folder_template_by_substring(folders, 'domain')}/{component_name}Domain.cs", get_domain_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'view')}/{component_name}View.cs", get_view_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'adapter')}/I{component_name}Presenter.cs", get_presenter_interface_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'factory')}/{component_name}Factory.cs", get_factory_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'tests')}/{component_name}Tests.cs", get_godot_tests_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'nodes')}/{component_name}Node.cs", get_node_template(component_name, project_name))
    create_file(f"{get_folder_template_by_substring(folders, 'nodes')}/{component_name}InitializationNode.cs", get_initialization_node_template(component_name, project_name))

def get_node_template(component_name, project_name):
    return \
f"""using {project_name}.{component_name}.Core.Adapter;
using Godot;

namespace {project_name}.{component_name}.Godot.Nodes
{{
    public partial class {component_name}Node : Node, I{component_name}Presenter
    {{
    }}
}}
"""

def get_initialization_node_template(component_name, project_name):
    return \
f"""using {project_name}.{component_name}.Core.Factory;
using {project_name}.{component_name}.Core.Domain;
using Godot;

namespace {project_name}.{component_name}.Godot.Nodes
{{
    public partial class {component_name}InitializationNode : Node
    {{
        [Export]
        private {component_name}Node _{component_name[0].lower() + component_name[1:]};

        private {component_name}Factory factory = new();

        private void _Ready()
        {{
            Initialize();
        }}

        //This can be called either from _Ready if independent or from another orchestrator script
        public {component_name}Domain Initialize()
        {{
            var domain = factory.Create(_{component_name[0].lower() + component_name[1:]});
            return domain;
        }}

        public void _ExitTree()
        {{
            factory.Clear();
        }}
    }}
}}
"""   

def get_godot_tests_template(component_name, project_name):
    return \
f"""using GdUnit4;
using Moq;
using {project_name}.{component_name}.Core.Adapter;
using {project_name}.{component_name}.Core.Factory;
using static GdUnit4.Assertions;

namespace {project_name}.{component_name}.Core.Tests
{{
    [TestSuite]
    public class {component_name}Tests
    {{
        private readonly {component_name}Factory factory = new ();
        private Mock<I{component_name}Presenter> mockPresenter;

        [BeforeTest]
        public void SetUp()
        {{
            mockPresenter = new Mock<I{component_name}Presenter>();
        }}

        [TestCase]
        public void FactoryShouldCreateDomain()
        {{
            var domain = factory.Create(mockPresenter.Object);
            AssertThat(domain != null);
        }}
    }}    
}}
"""

#####################
# Shared
#####################

def create_file(path, content):
    if not os.path.exists(path):
        with open(path, 'w') as file:
            file.write(content)

def get_engine_folder_template(base_path, component_name, engine):
    if engine == 'Unity':
        return [
            f"{base_path}/Core",
            f"{base_path}/Tests",
            f"{base_path}/Unity",
            f"{base_path}/Core/{component_name}",
            f"{base_path}/Core/{component_name}/Domain",
            f"{base_path}/Core/{component_name}/View",
            f"{base_path}/Core/{component_name}/Adapter",
            f"{base_path}/Core/{component_name}/Factory",
            f"{base_path}/Unity/{component_name}",
            f"{base_path}/Unity/{component_name}/Behaviours",
            f"{base_path}/Unity/{component_name}/Prefabs",
            f"{base_path}/Unity/{component_name}/Data",
            f"{base_path}/Unity/{component_name}/Textures",
        ]
    elif engine == 'Godot': #Godot reccomends lowercase folder names
        return [
            f"{base_path}/core",
            f"{base_path}/tests",
            f"{base_path}/godot",
            f"{base_path}/core/{component_name}",
            f"{base_path}/core/{component_name}/domain",
            f"{base_path}/core/{component_name}/view",
            f"{base_path}/core/{component_name}/adapter",
            f"{base_path}/core/{component_name}/factory",
            f"{base_path}/godot/{component_name}",
            f"{base_path}/godot/{component_name}/nodes",
            f"{base_path}/godot/{component_name}/data",
            f"{base_path}/godot/{component_name}/textures",
        ]

def get_folder_template_by_substring(folders, substring):
    result = next((entry for entry in folders if substring in entry), None)
    if result is None:
        print(f"Error: Substring '{substring}' not found in any entry.")
        sys.exit(1)
    return result

def get_domain_template(component_name, project_name):
    return \
f"""using System;

namespace {project_name}.{component_name}.Core.Domain
{{
    public class {component_name}Domain : IDisposable
    {{
        public {component_name}Domain()
        {{

        }}

        public void Dispose()
        {{
            //Unsubscribe from events
        }}
    }}
}}
"""

def get_view_template(component_name, project_name):
    return \
f"""using System;
using {project_name}.{component_name}.Core.Adapter;
using {project_name}.{component_name}.Core.Domain;

namespace {project_name}.{component_name}.Core.View 
{{
    public class {component_name}View : IDisposable
    {{
        private readonly {component_name}Domain domain;
        private readonly I{component_name}Presenter presenter;
        
        public {component_name}View({component_name}Domain domain, I{component_name}Presenter presenter)
        {{
            this.domain = domain;
            this.presenter = presenter;
        }}

        public void Dispose()
        {{
            //Unsubscribe from events
        }}
    }}
}}
"""

def get_presenter_interface_template(component_name, project_name):
    return \
f"""namespace {project_name}.{component_name}.Core.Adapter
{{
    public interface I{component_name}Presenter
    {{
    }}
}}
"""

def get_factory_template(component_name, project_name):
    return \
f"""using {project_name}.{component_name}.Core.Domain;
using {project_name}.{component_name}.Core.View;
using {project_name}.{component_name}.Core.Adapter;
using System.Collections.Generic;
using System;

namespace {project_name}.{component_name}.Core.Factory
{{
    public class {component_name}Factory
    {{        
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        public {component_name}Factory()
        {{
        }}

        public {component_name}Domain Create(I{component_name}Presenter presenter)
        {{
            var domain = new {component_name}Domain();
            disposables.Add(domain);
            var view = new {component_name}View(domain, presenter);
            disposables.Add(view);
            return domain;
        }}

        public void Clear()
        {{
            foreach (var disposable in disposables)
            {{
                disposable.Dispose();
            }}
        }}
    }}
}}
"""

if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser(description="Create component folders and files.")
    parser.add_argument("component_name", type=str, help="Name of the component.")
    parser.add_argument("project_name", type=str, help="Name of the project.")
    parser.add_argument("engine", type=str, choices=['Unity', 'Godot'], help="Engine name (Unity or Godot).")

    args = parser.parse_args()
    
    base_path = os.getcwd()
    folders = get_engine_folder_template(base_path, args.component_name, args.engine)
    for folder in folders:
        os.makedirs(folder, exist_ok=True)

    if args.engine == 'Unity':
        create_unity_component(args.component_name, args.project_name, folders)
    elif args.engine == 'Godot':
        create_godot_component(args.component_name, args.project_name, folders)
    else:
        print(f"Unsupported engine: {args.engine}")

    print(f"Component '{args.component_name}' created successfully at {base_path}.")
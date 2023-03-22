﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//C# naming convention
//사용자정의 자료형의 이름: PascalCase (첫글자 대문자)
//public, protected, internal 멤버 변수 : PascalCase
//private 멤버 변수 : _camelCase
//지역변수 : camelCase
//함수: PascalCase



//namespace : 이름으로 메모리 공간을 식별하기위한 키워드
//일반적인 namespace 작명 : 팀/회사 이름, 기술스택이름, 기타세부카테고리

namespace ClassObjectInstance.UISystems.Characters
{
    internal class SwordMan
    {

    }
}

namespace ClassObjectInstance
{
    //클래스
    //캡슐화하기위한 사용자정의 자료형
    //추상화 : 객체들의 공통점을 추려내기
    internal class SwordMan
    {
        //접근 제한자 (Access Modifiers)
        //1. private: 외부 접근 불가능
        //2. public: 외부 접근 가능
        //3. internal: 동일 어셈블리에서 접근가능(동일 프로젝트 내에서만 접근 가능)
        //4. protected: 상속받은 자식 클래스에서만 접근 가능
        //클래스는 캡슐화를 위한 자료형이기 때문에 기본적으로 모든 멤버는 private이 디폴트
        

        //멤버 변수
        public String Name;
        public int Lv;
        private float _exp;
        private char _gender;

        //클래스 생성자
        //정의하지 않아도 default 생성자가 생략되어있음
        //해당 클래스 타입의 객체를 힙영역에 할당하고 해당 객체의 참조를 반환★ 객체에다 주소 넣고 그 주소로 가서 넣는 방식(간접적)
        public SwordMan() {
        }

        //소멸자
        //해당 객체를 메모리영역에서 해제할 때 호출하는 함수
        ~SwordMan() {
        }

        //멤버 함수
        public void Slash()
        {
            //this 키워드 : 호출한 객체 자기자신의 참조(생략되어있었음)
            Console.WriteLine($"{this.Name} 이(가) 베기를 시전했다.");
        }
    }
}
